using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject //Child of InteractiveObject, inherits all functionality
{   [Tooltip("The GameObject to toggle")]
    [SerializeField] private GameObject objectToToggle;
}
