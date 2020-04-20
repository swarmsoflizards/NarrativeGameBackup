using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detcts interactive elements the player is looking at
/// </summary>

public class DetectLookAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField] private Transform raycastOrigin;
    [Tooltip("How far from the raycastOrigin to search for interactive elements.")]
    [SerializeField] float maxRange = 5.0f;


    /// <summary>
    /// Event raised when the player looks at a different IInteractive
    /// </summary>
    public static event Action LookedAtInteractiveChanged;
    
    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive; //test if value being sent to lookedAtInteractive is already being stored there
            if (isInteractiveChanged) //if value HAS changed
            {
                lookedAtInteractive = value; //replace with new value
                LookedAtInteractiveChanged?.Invoke(); //invoke event if value isn't null
            }
        }
    }

    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red); //Draw ray in scene
        RaycastHit hitInfo; //Store info about object hit
        bool ObjectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange); //Cast ray

        IInteractive interactive = null; //Set base detected interactive to null

        LookedAtInteractive = interactive;

        if (ObjectWasDetected == true)
        {
            //Debug.Log($"Looking at: { hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>(); //Store interactive being detected
        }

        if (interactive != null)
        {
            lookedAtInteractive = interactive; //Store detected interactive in field
        }
    }

}
