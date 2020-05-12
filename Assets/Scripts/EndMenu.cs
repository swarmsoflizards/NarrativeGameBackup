using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class EndMenu : MonoBehaviour
{
    [Tooltip("Start menu scene")]
    [SerializeField] private string menuSceneName;
    [Tooltip("End menu panel")]
    [SerializeField] private GameObject endMenuCanvas;

    [Tooltip("The InteractiveNPC who, when the player is done interacting with them, will trigger the end of the game")]
    [SerializeField] private InteractiveNPC father2;

    private AudioSource audioSource;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        endMenuCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (father2.hasFinishedInteracting == true)
        {
            GameOver();
        }
    }

    public void PlaySoundEffect()
    {
        audioSource.Play();
    }

    private void GameOver()
    {
        OpenEndMenu();
    }

    private void OpenEndMenu()
    {
        endMenuCanvas.SetActive(true);
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
