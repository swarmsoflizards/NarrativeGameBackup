using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [Tooltip("Start menu scene")]
    [SerializeField] private string menuSceneName;
    [Tooltip("End menu panel")]
    [SerializeField] private GameObject endMenuCanvas;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        endMenuCanvas.SetActive(false);
    }

    public void PlaySoundEffect()
    {
        audioSource.Play();
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
