using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    //TODO: Add long description field
    //TODO: Add icon field

    public InventoryObject()
    {
        displayText = nameof(InventoryObject);
    }

    /// <summary>
    /// When the player interactis with an inventory object, we need to:
    /// 1. Add the inventory object to the PlayerInventory list
    /// 2. Remove the object from the game world / scene
     /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);

    }
}
