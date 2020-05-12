using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [Tooltip("Start menu scene")]
    [SerializeField] private string menuSceneName;
    [Tooltip("End menu panel")]
    [SerializeField] private GameObject endMenuPanel;

    [Tooltip("The InteractiveNPC who, when the player is done interacting with them, will trigger the end of the game")]
    [SerializeField] private InteractiveNPC father2;

    private AudioSource audioSource;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>(); //Search whole scene for controller and assign to instance
        endMenuPanel.SetActive(false);
        Cursor.visible = false; //Hides cursor
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor
        rigidbodyFirstPersonController.enabled = true; //Must be enabled after cursor lock
    }

    private void FixedUpdate()
    {
        if (father2.hasFinishedInteracting == true)
        {
            OpenEndMenu();
        }
    }

    public void PlaySoundEffect()
    {
        audioSource.Play();
    }

    public void ExitGameButtonClicked()
    {
        PlaySoundEffect();
        ExitGame();
    }

    private void OpenEndMenu()
    {
        endMenuPanel.SetActive(true);
        //endMenuPanel.interactable = true;
        rigidbodyFirstPersonController.enabled = false; //Must be disabled before cursor unlock
        Cursor.visible = true; //Shows cursor
        Cursor.lockState = CursorLockMode.None; //Unlocks cursor
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
