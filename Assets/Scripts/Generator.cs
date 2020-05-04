﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]

public class Generator : InteractiveObject
{
    [Tooltip("Assign gasoline GameObject here")]
    [SerializeField] private InventoryObject gasoline;

    [Tooltip("Text that displays when the generator is inactive")]
    [SerializeField] private string inactiveDisplayText;
    [Tooltip("Text that displays when the generator is active")]
    [SerializeField] private string activeDisplayText;

    [Tooltip("AudioClip that plays when the player interacts with the inactive generator")]
    [SerializeField] private AudioClip inactiveAudioClip;
    [Tooltip("AudioClip that plays when the player activates the generator")]
    [SerializeField] private AudioClip activeAudioClip;

    private bool HasGasoline => PlayerInventory.InventoryObjects.Contains(gasoline);
    private Animator animator;
    private bool isActive = false;

    public override string DisplayText
    {
        get
        {
            string toReturn; //Store text to return
            if (!isActive)
                toReturn = HasGasoline ? $"Use {gasoline.ObjectName}" : inactiveDisplayText; //return inactive DisplayText
            else
                toReturn = base.DisplayText; //return normal DisplayText

            return toReturn;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        isActive = false;
    }
        
    public override void InteractWith()
    {
        if (!isActive) //if inactive
        {
            Debug.Log("Interacted with generator!!!!");
            if (!HasGasoline) //does NOT have gas
            {
                audioSource.clip = inactiveAudioClip;
            }
            else //DOES have gas
            {
                audioSource.clip = activeAudioClip;
                animator.SetBool("shouldRun", true);
                displayText = activeDisplayText;
                Activate();
            }
        }
        base.InteractWith(); //Call all functionality in parent method
    }

    private void Activate()
    {
        isActive = true;
        PlayerInventory.InventoryObjects.Remove(gasoline);
    }

}

