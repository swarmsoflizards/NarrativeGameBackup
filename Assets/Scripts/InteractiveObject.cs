using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField] private string displayText = nameof(InteractiveObject); //Set display text in editor

    public string DisplayText => displayText; //Take DisplayText from IInteractive and set it to displayText 

    public void InteractWith()
    {
        Debug.Log($"Player has interacted with (gameObject.name).");
    }
}
