using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// This script contains the methods used by the buttons in the start menu
    /// </summary>

    [SerializeField] private string gameSceneName;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject CreditsPanel;

    private void Start()
    {
        MenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        MenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
