using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject Dialogue;
    bool player_detection = false;
   // public GameObject d_template;
   // public GameObject canva;
    public GameObject dialogueBox;
    public PlayerMovement playMovementScript;

    
    void Update()
    {
        // its going through this method as well 
        if (Input.GetKeyDown(KeyCode.E) && !playMovementScript.dialogue)
        {
            playMovementScript.dialogue = true;
            dialogueBox.SetActive(true); // Make sure to activate the dialogue UI
            Debug.Log("Dialogue Started");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            player_detection = true;
            if (Dialogue != null)
            {
                Dialogue.SetActive(false); // Disable the canvas when starting dialogue
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = false; // Player is no longer in range
            if (playMovementScript.dialogue)
            {
                // End dialogue
                playMovementScript.dialogue = false;
                dialogueBox.SetActive(false); // Hide the dialogue UI
            }
        }
    }
}

