using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character", fileName = "characterData")]
public class Character : ScriptableObject
{
    [SerializeField] Sprite portrait;
    [SerializeField] string speakerName;  

    public Sprite Portrait
    {
        get { return portrait; }    
    }
    public string SpeakerName
    {
        get { return speakerName; }
    }
}
