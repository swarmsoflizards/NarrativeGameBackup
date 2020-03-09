using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls that IInteractive's method
/// </summary>

public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField] private DetectLookAtInteractive detectLookedAtInteractive;

    void Update()
    {
        if (Input.GetButton("Interact"))
        {
            Debug.Log("Player pressed the Interact button.");
        }
    }
}
