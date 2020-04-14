using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveObject : MonoBehaviour, IInteractive
{
<<<<<<< HEAD
    [Tooltip("Where the interactive object text should display")]
    [SerializeField] private TextMeshProUGUI DisplayText;

    [Tooltip("What the interactive object's text should display")]
    [SerializeField] private string InteractiveObjectText;

    public void InteractWith()
    {
        DisplayText.text = InteractiveObjectText;
        Debug.Log($"Player has interacted with (gameObject.name).");
=======
    [SerializeField] private string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText; 

    public void InteractWith()
    {
        Debug.Log($"Player can interact with {gameObject.name}.");
>>>>>>> 5cc6383c349ae86211871ff6f8cd0a315fae7e59
    }
}
