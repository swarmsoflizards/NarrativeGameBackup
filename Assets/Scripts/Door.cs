using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent (typeof(Animator))]

public class Door : InteractiveObject
{
    [Tooltip("Check this box to lock the door")]
    [SerializeField] private bool isLocked = false;

    [Tooltip("Text that displays when the door is locked")]
    [SerializeField] private string lockedDisplayText = "Locked";

    [Tooltip("AudioClip that plays when the player interacts with a locked door")]
    [SerializeField] private AudioClip lockedAudioClip;
    [Tooltip("AudioClip that plays when the player opens a door")]
    [SerializeField] private AudioClip OpenAudioClip;

    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;

    private Animator animator;
    private bool isOpen = false;

    /// <summary>
    /// Using a constructor here to initialize display text in editor
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (!isLocked)
            {
                audioSource.clip = OpenAudioClip;
                //audioSource.Play();
                animator.SetBool("shouldOpen", true);
                displayText = string.Empty;
                isOpen = true;
            }
            else //if door IS locked
            {
                audioSource.clip = lockedAudioClip;
            }
            base.InteractWith(); //Call all functionality in parent method
        }
    }
}
