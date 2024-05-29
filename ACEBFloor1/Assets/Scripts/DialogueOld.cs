using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueOld : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject Dialogue;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(index); // actaually calling the method
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                NextLine();
            }
        }
    }

    void startDialogue()
    {
        Debug.Log("2");
        index = 0;

        if (Dialogue != null)
        {
            Dialogue.SetActive(false); // Disable the canvas when starting dialogue
        }

        Debug.Log("3");
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        
        foreach(char c in lines[index++].ToCharArray())
        {
            Debug.Log("4");
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
