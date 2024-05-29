using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenElevator : MonoBehaviour
{
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvas2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(Globals.Instance.Level2BossComplete == false)
        {
            canvas1.SetActive(true);
        }

        else
        {
            canvas2.SetActive(true);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
