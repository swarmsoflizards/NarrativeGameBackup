using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls that IInteractive's method
/// </summary>

public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive LookedAtInteractive;

    void Update()
    {
        if (Input.GetButton("Interact") && LookedAtInteractive != null)
        {
            Debug.Log("Player pressed the Interact button.");
            LookedAtInteractive.InteractWith();
        }
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive"></param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        LookedAtInteractive = newLookedAtInteractive;
    }

    #region Event subscription / unsubscription
    private void OnEnable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }
    #endregion
}
