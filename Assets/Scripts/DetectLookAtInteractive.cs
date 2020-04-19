﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField] private Transform raycastOrigin;
    [Tooltip("How far from the raycastOrigin to search for interactive elements.")]
    [SerializeField]float maxRange = 5.0f;

    public IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red); //Draw ray in scene
        RaycastHit hitInfo; //Store info about object hit
        bool ObjectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange); //Cast ray

        IInteractive interactive = null; //Set base detected interactive to null

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
