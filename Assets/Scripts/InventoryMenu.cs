using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
using TMPro;

public class InventoryMenu : MonoBehaviour
{
    [Tooltip("The prefab to go in the list of inventory items")]
    [SerializeField] private GameObject inventoryMenuItemTogglePrefab;
    [Tooltip("Content of the scrollview for the list of inventory items")]
    [SerializeField] private Transform inventoryListContentArea;
    [Tooltip("Place in the UI for displaying the name of the selected inventory item")]
    [SerializeField] private TMP_Text itemLabelText;
    [Tooltip("Place in the UI for displaying info about the selected inventory item")]
    [SerializeField] private TMP_Text descriptionAreaText;

    [Tooltip("The AudioSource to play when the player interacts with the inventory buttons")]
    [SerializeField] private AudioSource audioSourceButton; //ONLY FOR EXIT BUTTON

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

    #region Inventory Menu Functionality
    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
        //if (inventoryObjectToAdd.GetComponent<CraftingObject>() != null) & ()
        //{
            
        //}
    }

    public void ExitMenuButtonClicked()
    {
        audioSourceButton.Play();
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

    /// <summary>
    /// This is the event handler for the InventoryMenuItemSelected
    /// </summary>
    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
    }

    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("InventoryToggle"))
            if (IsVisible)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
                
    }
    #endregion

    #region Initialize + Start
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMenu in the scene.");

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
        audioSource.volume = 2; //Return volume to normal
    }
    #endregion
}
