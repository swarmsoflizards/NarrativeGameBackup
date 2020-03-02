using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//referenced from: https://github.com/jiankaiwang/FirstPersonController

public class CharacterController : MonoBehaviour
{

    [SerializeField] float speed = 10.0f; //speed
    private float translation; //translation
    private float strafe; //strafe

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //turn off cursor
    }
    private void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime; //get vertical position
        strafe = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //get horizontal position
        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape")) //on escape key
        {
            Cursor.lockState = CursorLockMode.None; //turn on cursor
        }
    }
}
