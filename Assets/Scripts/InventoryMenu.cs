using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is no InventoryMenu instance in the scene." +
                     "Make sure the InventoryMenu script is applied to a GameObjecyt in your scene.");
            return instance;
        }
        private set { instance = value; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMeny in the scene.");
    }
}
