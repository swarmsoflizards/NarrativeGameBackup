using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent (typeof(Animator))]

public class Door : InteractiveObject
{
    private Animator animator;

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
        base.InteractWith(); //Call all functionality in parent method
        animator.SetBool("shouldOpen", true);
        audioSource.Play();
        Debug.Log($"Player has opened door.");
    }
}
