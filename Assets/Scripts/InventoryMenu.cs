using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is no InventoryMenu instance in the scene." +
                     "Make sure the InventoryMenu script is applied to a GameObjecyt in your scene.");
            return instance;
        }
        private set { instance = value; }
    }

    private bool IsVisible => canvasGroup.alpha > 0;
    
    private void ShowMenu()
    {
        canvasGroup.alpha = 1; //Show canvas group
        canvasGroup.interactable = true;
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0; //Hide canvas group
        canvasGroup.interactable = false;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("InventoryToggle"))
            if (IsVisible)
                HideMenu();
            else
                ShowMenu();
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMeny in the scene.");

        canvasGroup = GetComponent<CanvasGroup>(); //Initialize canvas group
        HideMenu();
    }
}
