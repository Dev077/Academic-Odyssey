using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerer : MonoBehaviour
{
    public GameObject dialogueBoxPrefab; // Reference to the dialogue box prefab
    public GameObject Canvas;

    private void OnMouseDown()
    {
        if (dialogueBoxPrefab != null)
        {
            // Instantiate the dialogue box prefab
            GameObject dialogueBoxInstance = Instantiate(dialogueBoxPrefab, transform.position, Quaternion.identity);
            // Attach it to the Canvas or any other parent GameObject as needed
            dialogueBoxInstance.transform.SetParent(Canvas.transform, false);
        }
    }
}
