using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDialogue : MonoBehaviour
{

    public Material[] lines;
    bool isOpen = false;
    int index = 0;

    void OnMouseDown()
    {

        Transform box = transform.Find("Dialogue");
        Renderer dBox = box.GetComponent<Renderer>();

        if (index > lines.Length - 1)
        {
            box.gameObject.SetActive(false);
            index = 0;
            isOpen = false;
        }
        else if (box != null && isOpen == false)
        {
            box.gameObject.SetActive(true);
            isOpen = true;
            dBox.material = lines[index];
            index ++;
        }

        else if (box != null && isOpen == true) {
            dBox.material = lines[index]; 
            index ++;
        }
    }
}
