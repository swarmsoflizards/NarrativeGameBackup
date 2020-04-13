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
    [SerializeField] private GameObject Attribution1Panel;
    [SerializeField] private GameObject Attribution2Panel;

    private void Start()
    {
        ShowMenuPanel();
    }

    public void ShowMenuPanel() //On start and exit credits
    {
        MenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        Attribution1Panel.SetActive(false);
        Attribution2Panel.SetActive(false);
    }

    public void LoadGameScene() //Press start button
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ShowCreditsPanel() //Press credits button
    {
        CreditsPanel.SetActive(true);
    }

    public void ShowAttribution1Panel() //Press attribution panel
    {
        CreditsPanel.SetActive(false);
        Attribution1Panel.SetActive(true);
        Attribution2Panel.SetActive(false);
    }

    public void ShowAttribution2Panel() //Press attribution panel
    {
        CreditsPanel.SetActive(false);
        Attribution1Panel.SetActive(false);
        Attribution2Panel.SetActive(true);
    }

    public void ExitGame() //Press quit button
    { 
        Debug.Log("Quit game");
        Application.Quit();
    }
}
