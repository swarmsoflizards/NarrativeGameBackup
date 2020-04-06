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

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
