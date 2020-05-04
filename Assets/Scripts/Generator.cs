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

    [Tooltip("AudioClip that plays when the player activates the generator")]
    [SerializeField] private AudioClip switchAudioClip;
    [Tooltip("AudioClip that plays when when the generator is turned on")]
    [SerializeField] private AudioClip engineAudioClip;

    private bool HasGasoline => PlayerInventory.InventoryObjects.Contains(gasoline);
    private Animator animator;
    //private AudioSource engineAudioSource;
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
        //engineAudioSource = GetComponent<AudioSource>();
        isActive = false;
        //audioSource.clip = switchAudioClip;
        //engineAudioSource.clip = engineAudioClip;
    }
        
    public override void InteractWith()
    {
        if (!isActive) //if inactive
        {
            if (!HasGasoline) //does NOT have gas
            {
                audioSource.clip = switchAudioClip;
            }
            else //DOES have gas
            {
                audioSource.clip = engineAudioClip;
                //StartCoroutine(WaitForAudioClip());
                //engineAudioSource.Play();
                animator.SetBool("shouldRun", true);
                displayText = activeDisplayText;
                Activate();
            }
        }
        else //if already active
        {
            audioSource.clip = switchAudioClip;
            animator.SetBool("shouldRun", false);
            displayText = inactiveDisplayText;
            Deactivate();
        }
        base.InteractWith(); //Call all functionality in parent method
    }

    private void Activate()
    {
        isActive = true;
        PlayerInventory.InventoryObjects.Remove(gasoline);
    }

    private void Deactivate()
    {
        isActive = false;
    }

    //private IEnumerator WaitForAudioClip()
    //{
    //    //audioSource.clip = switchAudioClip;
    //    yield return new WaitForSeconds(switchAudioClip.length);
    //    //audioSource.clip = engineAudioClip;
    //}

}

