using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]

public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If the player has the key in their inventory, they can open the locked door")]
    [SerializeField] private InventoryObject key;

    [Tooltip("If this is checked, the key will be removed from the player's inventory when the door is unlocked")]
    [SerializeField] private bool consumesKey;

    [Tooltip("Text that displays when the door is locked")]
    [SerializeField] private string lockedDisplayText = "Locked";

    [Tooltip("AudioClip that plays when the player interacts with a locked door")]
    [SerializeField] private AudioClip lockedAudioClip;
    [Tooltip("AudioClip that plays when the player opens a door")]
    [SerializeField] private AudioClip OpenAudioClip;

    //public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    public override string DisplayText
    {
        get
        {
            string toReturn; //Store text to return
            if (isLocked)
                toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText; //return locked DisplayText
            else
                toReturn = base.DisplayText; //return normal DisplayText

            return toReturn;
        }
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key); //does InventoryObjects list contain key
    private Animator animator;
    private bool isOpen = false;
    private bool isLocked = false;

    /// <summary>
    /// Using a constructor here to initialize display text in editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null) //If a key is assigned
            isLocked = true; //lock the door
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {

            if (isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else //if unlocked OR locked and have key
            {
                audioSource.clip = OpenAudioClip;
                animator.SetBool("shouldOpen", true); //activate animator parameter
                displayText = string.Empty; //empty display text
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith(); //Call all functionality in parent method
        }
    }

    private void UnlockDoor()
    {

        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.InventoryObjects.Remove(key);
    }
}
