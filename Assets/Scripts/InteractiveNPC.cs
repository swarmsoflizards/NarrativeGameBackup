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
    [Tooltip("The 3rd line of dialogue the character will speak")]
    [SerializeField] private string dialogue3;
    [Tooltip("The 4th line of dialogue the character will speak")]
    [SerializeField] private string dialogue4;
    [Tooltip("The 5th line of dialogue the character will speak")]
    [SerializeField] private string dialogue5;
    [Tooltip("The 6th line of dialogue the character will speak")]
    [SerializeField] private string dialogue6;
    [Tooltip("The 7th line of dialogue the character will speak")]
    [SerializeField] private string dialogue7;
    [Tooltip("The 8th line of dialogue the character will speak")]
    [SerializeField] private string dialogue8;

    private string dialogueToDisplay;
    private int numberOfInteractions = 0;
    public bool hasFinishedInteracting = false;

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
        //Debug.Log("Number of interactions with " + NPCName + ": " + numberOfInteractions);
        SpeakNPCDialogue();
        displayText = dialogueToDisplay;
        base.InteractWith();
        numberOfInteractions++;
        if (dialogueToDisplay == null)
        {

        }
    }

    private void SpeakNPCDialogue()
    {
        if (numberOfInteractions == 0)
            dialogueToDisplay = dialogue1;
        else if (numberOfInteractions == 1)
            dialogueToDisplay = dialogue2;
        else if (numberOfInteractions == 2)
            dialogueToDisplay = dialogue3;
        else if (numberOfInteractions == 3)
            dialogueToDisplay = dialogue4;
        else if (numberOfInteractions == 4)
            dialogueToDisplay = dialogue5;
        else if (numberOfInteractions == 5)
            dialogueToDisplay = dialogue6;
        else if (numberOfInteractions == 6)
            dialogueToDisplay = dialogue7;
        else if (numberOfInteractions == 7)
            dialogueToDisplay = dialogue8;
        else if (numberOfInteractions >= 8)
        {
            dialogueToDisplay = null;
            hasFinishedInteracting = true;
        }
    }

}
