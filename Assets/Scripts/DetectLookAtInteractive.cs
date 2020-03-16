using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects elements the player is looking at
/// </summary>

public class DetectLookAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField] private Transform raycastOrigin;
    [Tooltip("How far from the raycastOrigin to search for interactive elements.")]
    [SerializeField] float maxRange = 5.0f;

    /// <summary>
    /// Event raised whem the player looks at a different IInteractive
    /// </summary>

    public static event Action<IInteractive> LookedAtInteractiveChanged;

    public IInteractive LookedAtInteractive //Property controls ability to access values
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive; //If LookedAtInteractive has changed, set bool to true
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value; //Update value; only allow value to be changed in this class
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive); //If LookedAtInteractiveChanged is not null, raise event
            }
        } 
    }

    private IInteractive lookedAtInteractive; //Store the interactive being looked at

    private void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive(); //Store interactive or null in LookedAtInteractive
    }

    #region GetLookedAtInteractive method
    /// <summary>
    /// Raycasts forward from the camera to look for IInteractives
    /// </summary>
    /// <returns>The first IInteractive detected, or null if there are none</returns>
    private IInteractive GetLookedAtInteractive()
    {
        RaycastHit hitInfo; //Store info about object hit
        bool ObjectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange); //Cast ray
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red); //Draw ray in scene

        IInteractive interactive = null; //Store object being interacted with

        LookedAtInteractive = interactive; //Change variable to value being passed in

        if (ObjectDetected == true) //If there is any object detected by ray
        {
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>(); //Get the info of the object
        }

        return interactive; //Return reference to interactive object
    }
    #endregion
}
