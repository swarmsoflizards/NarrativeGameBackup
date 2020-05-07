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

    private bool HasObjectToBePowered => PlayerInventory.InventoryObjects.Contains(objectToBePowered);
    private bool HasObjectCord => PlayerInventory.InventoryObjects.Contains(objectCord);

    public override void InteractWith()
    {
        if (!HasObjectCord && !HasObjectToBePowered)
        {
            Debug.Log("Player has tried to power something, but is missing one of the components");
        }
        else
        {
            Debug.Log("Player has powered " + objectToBePowered + " with " + objectCord);
        }
        base.InteractWith();
    }
}
