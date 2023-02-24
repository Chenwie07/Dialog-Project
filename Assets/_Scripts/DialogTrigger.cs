using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    public Character npcData;

    [SerializeField, TextArea(2, 3)]
    List<string> lines = new List<string>();

    public bool isNext = false;

    public void TriggerDialog()
    {
        DialogManager.Instance.SetupConversationDetails(npcData, lines, isNext);
        this.enabled = false;
    }
}