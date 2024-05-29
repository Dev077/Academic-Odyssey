using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvas2;
    

    
    // Start is called before the first frame update
    void Start()
    {
       // canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Globals.Instance.clickCount++;
        if (Globals.Instance.clickCount == 1)
        {
            
            canvas1.SetActive(true);
        }
        else
        {
            
           
            canvas2.SetActive(true);
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None
      ;
    }
}
