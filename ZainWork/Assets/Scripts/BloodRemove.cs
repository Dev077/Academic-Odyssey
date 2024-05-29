using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRemove : MonoBehaviour
{ 
    int counter;


    // Start is called before the first frame update
    private void OnMouseDown()
    {
        counter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter >= 5)
        {
            Destroy(gameObject);
        }
    }
}
