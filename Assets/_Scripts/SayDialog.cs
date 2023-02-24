using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SayDialog : MonoBehaviour
{

    public Image portrait;
    public TextMeshProUGUI portraitName;
    public TextMeshProUGUI textWindow;

    [SerializeField, Range(0, 0.2f)]
    float typeSpeed = 0.3f; 

    public void SetProfile(Sprite pic, string name)
    {
        portrait.sprite = pic;
        portraitName.text = name;
    }
    public void WriteText(string line)
    {
        // we can then set our coroutine here. 
        textWindow.text = ""; // clear the window. 
        StartCoroutine(Typewrite(line, typeSpeed));
    }

    IEnumerator Typewrite(string line, float typeSpeed)
    {
        for (int i = 0; i < line.Length; i++)
        {
            textWindow.text += line[i];
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return null; 
    }
}
