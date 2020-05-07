using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingObject : InventoryObject
{
    [Tooltip("The GameObject being crafted")]
    [SerializeField] private InventoryObject resultingItem;

    [Tooltip("The GameObject to combine this GameObject with")]
    [SerializeField] private InventoryObject craftingComponent;

    public override void InteractWith()
    {
        base.InteractWith();
        if (PlayerInventory.InventoryObjects.Contains(craftingComponent))
        {
            PlayerInventory.InventoryObjects.Remove(this);
            PlayerInventory.InventoryObjects.Remove(craftingComponent);
            InventoryMenu.Instance.AddItemToMenu(resultingItem);
        }
        else
        {

        }

    }

}
