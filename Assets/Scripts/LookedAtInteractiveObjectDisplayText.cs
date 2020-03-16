using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This UI text displays info about the currently looked at interactive IInteractive.
/// The text should be hidden if the player is not currently looking at an interactive element.
/// </summary>

public class LookedAtInteractiveObjectDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractiveObject;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractiveObject != null)
        {
            displayText.text = lookedAtInteractiveObject.DisplayText;
        }
        else
        {
            displayText.text = string.Empty;
        }
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive that the player is lookning at</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive) //When looked at interactive changes, update display text
    {
        lookedAtInteractiveObject = newLookedAtInteractive; //Set new interactive to lookedAtInteractiveObject
        UpdateDisplayText();
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
