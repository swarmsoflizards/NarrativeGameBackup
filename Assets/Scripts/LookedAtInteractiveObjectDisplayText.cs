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
}
