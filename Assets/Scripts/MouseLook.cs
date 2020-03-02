using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//referenced from: https://github.com/jiankaiwang/FirstPersonController

public class MouseLook : MonoBehaviour
{
    [SerializeField] public float sensitivity = 5.0f;
    [SerializeField] public float smoothing = 2.0f;
    [SerializeField] GameObject player; //set player
    private Vector2 mouseLook; //get value of mouse
    private Vector2 smoothV; //smooth

    void Start()
    {
        player = this.transform.parent.gameObject; //initialize
    }

    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV; //add to camera look

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
