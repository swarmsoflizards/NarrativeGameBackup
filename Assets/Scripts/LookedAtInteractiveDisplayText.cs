using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This UI text displays info about the currently looked at IInteractive element
/// The text should be hidden if the player is not currently looking at an interactive element
/// </summary>

public class LookedAtInteractiveDisplayText : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    [Tooltip("Text field to display interactive object text")]
    [SerializeField] protected TMP_Text displayText;

    private void Awake()
    {

        //displayText = GetComponent<TMP_Text>(); //Assign displayText to attached TMP_Text
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null) //if looking at interactive
        {
            displayText.text = lookedAtInteractive.DisplayText; //Get and display text from InteractiveObject.cs
        }
        else
        {
            displayText.text = string.Empty;
        }
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the player is looking at</param>

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
    }

    #region Event subsccription / unsubscription
    private void OnEnable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;

    }
    #endregion
}
