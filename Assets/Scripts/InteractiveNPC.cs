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
    [Tooltip("AudioClip that plays when the player interacts with NPC")]
    [SerializeField] private AudioClip audioClip;

    [Tooltip("The character's name, to display on raycast")]
    [SerializeField] private string NPCName;

    [Tooltip("The 1st line of dialogue the character will speak")]
    [SerializeField] private string dialogue1;
    [Tooltip("The 2nd line of dialogue the character will speak")]
    [SerializeField] private string dialogue2;

    private int numberOfInteractions = 0;

    public InteractiveNPC()
    {
        displayText = NPCName;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void InteractWith()
    {
        Debug.Log("Number of interactions with " + NPCName + ": " + numberOfInteractions);
        SpeakNPCDialogue();
        base.InteractWith();
        numberOfInteractions++;
    }

    private void SpeakNPCDialogue()
    {
        if (numberOfInteractions == 0)
            displayText = dialogue1;
        else if (numberOfInteractions == 1)
            displayText = dialogue2;
    }

    private void TakePlayerResponse()
    {

    }

}
