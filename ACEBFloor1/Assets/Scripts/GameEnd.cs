using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public int numOfClicks;
    int counter;
    [SerializeField] GameObject canvas1;


    private void OnMouseDown()
    {
        counter += 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= numOfClicks)
        {
            Destroy(gameObject);
        }
        if (counter == 75)
        {
            canvas1.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
