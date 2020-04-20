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
    private TMP_Text displayText;

    private void Awake()
    {
        displayText = GetComponent<TMP_Text>(); //Assign displayText to attached TMP_Text
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
}
