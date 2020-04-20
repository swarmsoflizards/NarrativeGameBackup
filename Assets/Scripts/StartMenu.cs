using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    /// <summary>
    /// This script contains the methods used by the buttons in the start menu
    /// </summary>

    #region Assign scenes and panels
    [Tooltip("Game scene")]
    [SerializeField] private string gameSceneName;
    [Tooltip("Start menu panel")]
    [SerializeField] private GameObject MenuPanel;
    [Tooltip("Start credits panel")]
    [SerializeField] private GameObject CreditsPanel;
    [Tooltip("Start attribution panel 1")]
    [SerializeField] private GameObject Attribution1Panel;
    [Tooltip("Start attribution panel 2")]
    [SerializeField] private GameObject Attribution2Panel;
    #endregion

    private void Start()
    {
        ShowMenuPanel();
    }

    #region Inter-menu navigation
    public void ShowMenuPanel() //On start and exit credits
    {
        MenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        Attribution1Panel.SetActive(false);
        Attribution2Panel.SetActive(false);
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
    #endregion

    public void LoadGameScene() //Press start button
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame() //Press quit button
    { 
        Debug.Log("Quit game");
        Application.Quit();
    }
}
