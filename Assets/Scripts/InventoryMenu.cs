using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private AudioSource audioSource;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is no InventoryMenu instance in the scene." +
                     "Make sure the InventoryMenu script is applied to a GameObject in your scene.");
            return instance;
        }
        private set { instance = value; }
    }

    private bool IsVisible => canvasGroup.alpha > 0; //Allows editing of canvas group visibility

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }
    
    private void ShowMenu()
    {
        canvasGroup.alpha = 1; //Show canvas group
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false; //Must be disabled before cursor unlock
        Cursor.visible = true; //Shows cursor
        Cursor.lockState = CursorLockMode.None; //Unlocks cursor
        audioSource.Play();
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0; //Hide canvas group
        canvasGroup.interactable = false;
        Cursor.visible = false; //Hides cursor
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor
        rigidbodyFirstPersonController.enabled = true; //Must be enabled after cursor lock
        audioSource.Play();
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
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>(); //Search whole scene for controller and assign to instance
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        HideMenu(); //Avoid hiding menu before finding character controller
        StartCoroutine(WaitForAudioClip()); //Keep sound effect from playing on Start
    }

    private IEnumerator WaitForAudioClip()
    {
        float originalVolume = audioSource.volume; //Save volume defined in editor

        audioSource.volume = 0; //Set sound effect volume to 0
        yield return new WaitForSeconds(audioSource.clip.length); //Wait for sound effect to play at 0
        audioSource.volume = originalVolume; //Return volume to normal
    }
}
