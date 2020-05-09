using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("The image component used to show the associated object's icon")]
    [SerializeField] private Image iconImage;
    [Tooltip("The AudioSource to play when the player interacts with the inventory buttons")]
    [SerializeField] private AudioSource audioSourceButton;

    public static event Action<InventoryObject> InventoryMenuItemSelected;
    private InventoryObject associatedInventoryObject;

    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }

    /// <summary>
    /// This will be plugged into the toggle's "OnValueChanged" property in the editor
    /// and called whenever the toggle is clicked
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        audioSourceButton.Play();
        //We only want to do anything when the toggle is selected
        if (isOn)
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
    }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
}
