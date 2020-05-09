using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the behavior of power sockets. They are assigned TO the power source/generator, 
/// and then have the InventoryObject they give power to on interaction assigned to them. 
/// </summary>

public class PowerSocket : InteractiveObject
{
    [Tooltip("Assign GameObject to power here")]
    [SerializeField] private InventoryObject objectToBePowered;
    [Tooltip("Assign GameObject to power here")]
    [SerializeField] private InventoryObject objectCord;

    [Tooltip("Enter the text that will display when the player can interact with the power socket")]
    [SerializeField] private string interactableDisplayText;

    [Tooltip("AudioClip that plays when the player charges the object")]
    [SerializeField] private AudioSource chargedAudioClip;

    [Tooltip("Assign Father instance to spawn here")]
    [SerializeField] private InteractiveNPC FatherInstance2;
    [Tooltip("Assign GameObject to power here")]
    [SerializeField] private Vector3 fatherInstantiateLocation;

    private bool hasBeenInteractedWith = false;

    private bool HasObjectToBePowered => PlayerInventory.InventoryObjects.Contains(objectToBePowered);
    private bool HasObjectCord => PlayerInventory.InventoryObjects.Contains(objectCord);

    private void FixedUpdate()
    {
        if (HasObjectCord && HasObjectToBePowered)
            displayText = interactableDisplayText;


    }

    public override void InteractWith()
    {
        if (!HasObjectCord && !HasObjectToBePowered)
        {
            Debug.Log("Player has tried to power something, but is missing one of the components");
        }
        else
        {
            chargedAudioClip.Play();
            Debug.Log("Player has powered " + objectToBePowered + " with " + objectCord);
            hasBeenInteractedWith = true;
            if (hasBeenInteractedWith)
            {
                Instantiate(FatherInstance2);
                FatherInstance2.transform.position = fatherInstantiateLocation;
            }
        }
        base.InteractWith();
    }
}
