using System.Collections;
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

    [Tooltip("AudioClip that plays when the player interacts with the inactive generator")]
    [SerializeField] private AudioClip inactiveAudioClip;
    [Tooltip("AudioClip that plays when the player activates the generator")]
    [SerializeField] private AudioClip activeAudioClip;

    private Animator animator;
    private bool isActive = false;

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        isActive = false;
    }
        
    public override void InteractWith()
    {
        if (!isActive)
        {
            audioSource.clip = inactiveAudioClip;
        }
        else
        {

        }
        base.InteractWith(); //Call all functionality in parent method
    }

    private void Activate()
    {

    }

}

