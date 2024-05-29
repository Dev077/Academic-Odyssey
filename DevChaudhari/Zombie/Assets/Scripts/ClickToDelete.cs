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
        Debug.Log("click");
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= numOfClicks)
        {
            Destroy(gameObject);
        }
    }
}
