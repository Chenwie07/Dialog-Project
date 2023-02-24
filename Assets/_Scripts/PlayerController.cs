using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canTalk { get; internal set; }
    private float speed = 3f;
    float moveX; 
    // Update is called once per frame
    void Update()
    {
        if (DialogManager.Instance.isRunning)
            return; 

        moveX = Input.GetAxis("Horizontal"); 
        if (Input.GetKeyDown(KeyCode.Space) && canTalk)
        {
            FindObjectOfType<DialogTrigger>().TriggerDialog();
            // lock controls 
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * moveX * speed *  Time.deltaTime); 
    }
}
