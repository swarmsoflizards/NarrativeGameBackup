using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject //Child of InteractiveObject, inherits all functionality
{   [Tooltip("The GameObject to toggle")]
    [SerializeField] private GameObject objectToToggle;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this object
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith(); //Call all functionality in parent method
        objectToToggle.SetActive(!objectToToggle.activeSelf); //SetActive to reverse of current state
    }
}
