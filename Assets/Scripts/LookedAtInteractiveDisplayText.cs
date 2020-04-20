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
}
