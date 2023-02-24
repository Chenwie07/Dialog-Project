using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * Controls when a Dialog has started/ended with events
 * Moves the Dialog along by changing the speaker info and the lines being said
 * Take the lines and info from the Dialog Trigger to carry out Operations. 
 */

public class DialogManager : MonoBehaviour
{
    // Quick Singleton
    public static DialogManager Instance;

    public Character player;
    private Character npc;

    private List<string> dialogLines = new List<string>();
    private int lineIdx;
    private bool firstSpeaker;
    public bool isRunning = false;

    public SayDialog _sayDialog;

    // use events. 
    public UnityEvent @onDialogEnded;
    public UnityEvent @onDialogStarted;

    private void Awake()
    {
        Instance = this;
        isRunning = false;
    }

    internal void SetupConversationDetails(Character npcData, List<string> lines, bool _whoFirst)
    {
        npc = npcData;
        dialogLines.AddRange(lines);
        lineIdx = 0;
        BeginDialog();
    }
    private void BeginDialog()
    {
        _sayDialog.gameObject.SetActive(true); 
        WriteDialog(lineIdx, npc);
        onDialogStarted.Invoke();
    }

    public void WriteDialog(int idx, Character speaker)
    {
        _sayDialog.SetProfile(speaker.Portrait, speaker.SpeakerName);
        _sayDialog.WriteText(dialogLines[idx]); // the 0 will then become a changing index. 
    }

    public void NextLine()
    {
        Character speaker;
        speaker = firstSpeaker == true ? npc : player;

        if (lineIdx < dialogLines.Count - 1)
        {
            lineIdx++;
            // swap Profile Picture. 
            WriteDialog(lineIdx, speaker);
            firstSpeaker = !firstSpeaker;
            print(firstSpeaker);
        }
        else
        {
            onDialogEnded.Invoke();
            _sayDialog.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        onDialogEnded.AddListener(RestoreControls);
        onDialogStarted.AddListener(BlockControls);
    }

    public void RestoreControls() => isRunning = false;
    public void BlockControls() => isRunning = true;

    private void OnDisable()
    {
        onDialogEnded.RemoveListener(RestoreControls);
        onDialogStarted.RemoveListener(BlockControls); 
    }
}
