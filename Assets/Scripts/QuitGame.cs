using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("QuitGame"))
        {
            Debug.Log("Player has quit the game.");
            Application.Quit();
        }
    }
}
