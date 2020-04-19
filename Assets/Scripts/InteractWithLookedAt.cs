using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls that IInteractive's InteractWith method
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    [SerializeField] private DetectLookAtInteractive detectLookedAtInteractive;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive.lookedAtInteractive != null)
        {
            Debug.Log("Player pressed the interact button.");
            detectLookedAtInteractive.lookedAtInteractive.InteractWith();
        }
    }
}
