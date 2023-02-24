using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public PlayerController player;
    public GameObject chatBox; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            player.canTalk = true;
            chatBox.SetActive(true); 
        }else
        {
            player.canTalk = false; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.canTalk = false;
        chatBox.SetActive(false);

    }
}
