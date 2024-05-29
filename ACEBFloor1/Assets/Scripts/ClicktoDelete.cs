using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDelete : MonoBehaviour
{
    public int numOfClicks;
    int counter;


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
            Debug.Log("You Win");
        }
    }
}