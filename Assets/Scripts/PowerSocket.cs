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
    [SerializeField] private InventoryObject objectToBePluggedIn;

    private bool HasObjectToBePluggedIn => PlayerInventory.InventoryObjects.Contains(objectToBePluggedIn);

    public override void InteractWith()
    {
        Debug.Log("Player has plugged in and powered " + objectToBePluggedIn);
        base.InteractWith();
    }
}
