using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField] private Transform raycastOrigin;
    [Tooltip("How far from the raycastOrigin to search for interactive elements.")]
    [SerializeField]float maxRange = 5.0f;

    private Vector3 raycastDirection;

    private void FixedUpdate()
    {
        Physics.Raycast(raycastOrigin.position, raycastDirection, maxRange); 
    }

}
