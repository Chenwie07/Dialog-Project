using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Takes the Lines to be said and the data of the Dialog Trigger
 * NPC data to be passed to Dialog Manager to carry on Discussion between NPC and Player
 */
public class DialogTrigger : MonoBehaviour
{
    public Character npcData;

    // for voice overs define this as a structure with lines and audio clip. 
    [SerializeField, TextArea(2, 3)]
    List<string> lines = new List<string>();

    public bool isNext = false;

    public void TriggerDialog()
    {
        DialogManager.Instance.SetupConversationDetails(npcData, lines, isNext);
        this.enabled = false;
    }
}