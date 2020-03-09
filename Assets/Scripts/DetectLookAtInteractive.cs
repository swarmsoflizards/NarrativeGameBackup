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
    [SerializeField]float maxRange = 5.0f;

    public IInteractive lookedAtInteractive; //Store the interactive being looked at

    private void FixedUpdate()
    {
        RaycastHit hitInfo; //Store info about object hit
        bool ObjectDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange); //Cast ray
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red); //Draw ray in scene

        IInteractive interactive = null; //Store object being interacted with

        if (ObjectDetected == true) //If there is any object detected by ray
        {
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>(); //Get the info of the object
        }

        if (interactive != null) //If there is an interactive object
        {
            lookedAtInteractive = interactive; //Set the interactive being looked at in interactive
        }
    }

}
