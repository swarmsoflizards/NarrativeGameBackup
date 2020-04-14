using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Where the interactive object text should display")]
    [SerializeField] private TextMeshProUGUI DisplayText;

    [Tooltip("What the interactive object's text should display")]
    [SerializeField] private string InteractiveObjectText;

    public void InteractWith()
    {
        DisplayText.text = InteractiveObjectText;
        Debug.Log($"Player has interacted with (gameObject.name).");
    }
}
