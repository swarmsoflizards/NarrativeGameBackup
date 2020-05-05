using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This script controlls the behavior of NPCs, which are just different Interactive Objects.
/// They need to:
/// 1. Display dialogue text when interacted with
/// 2. Cycle through that dialogue text when interacted with again
/// 3. Be able to be instantiated in another location
/// 4. Track the number of interactions the player has had with it
/// </summary>
public class InteractiveNPC : InteractiveObject
{
    [Tooltip("The character's name, to display on raycast")]
    [SerializeField] private string NPCName;

    [Tooltip("AudioClip that plays when the player interacts with NPC")]
    [SerializeField] private AudioClip audioClip;

    private int numberOfInteractions = 0;

    public InteractiveNPC()
    {
        displayText = NPCName;
    }

    public override void InteractWith()
    {
        numberOfInteractions++;
        Debug.Log("Number of interactions with " + NPCName + ": " + numberOfInteractions);
        SpeakDialogue();
        TakeResponse();
        base.InteractWith();
    }

    private void SpeakDialogue()
    {

    }

    private void TakeResponse()
    {

    }
}
