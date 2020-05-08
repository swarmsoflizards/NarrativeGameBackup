using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text that will display while looking at the object in the world")]
    [SerializeField] protected string displayText = nameof(InteractiveObject); //Set display text in editor

    public virtual string DisplayText => displayText; //Take DisplayText from IInteractive and set it to displayText 
    protected AudioSource audioSource;

    public virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
}
