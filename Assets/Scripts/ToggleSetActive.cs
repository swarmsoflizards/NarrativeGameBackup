using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject //Child of InteractiveObject, inherits all functionality
{
    [Tooltip("The GameObject to toggle")]
    [SerializeField] private GameObject objectToToggle;

    [Tooltip("Can the player interact with this more than once?")]
    [SerializeField] private bool isReusable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this object
    /// </summary>
    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith(); //Call all functionality in parent method
            objectToToggle.SetActive(!objectToToggle.activeSelf); //SetActive to reverse of current state
            hasBeenUsed = true;
            if (!isReusable) displayText = string.Empty; //Empty displayText if toggle is not reusable
        }
    }
}
