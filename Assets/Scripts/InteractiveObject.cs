using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Where the interactive object text should display")]
    [SerializeField] private TMP_Text DisplayText;

    [Tooltip("What the interactive object's text should display")]
    [SerializeField] private string InteractiveObjectText;

    //private TMP_Text DisplayText;

    //private void Awake()
    //{
    //    DisplayText = GetComponent<TMP_Text>();
    //}

    public void InteractWith()
    {
        DisplayText.text = InteractiveObjectText;
        Debug.Log($"Player has interacted with (gameObject.name).");
    }
}
