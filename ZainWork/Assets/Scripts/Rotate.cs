using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    private Dictionary<string, string> buttonToWheelMap = new Dictionary<string, string>()
    {
        {"Button1", "WheelOne"},
        {"Button2", "WheelTwo"},
        {"Button3", "WheelThree"},
        {"Button4", "WheelFour"}
    };

        private void OnMouseDown()
       {
           if (coroutineAllowed)
           {
                StartCoroutine("RotateWheel");
           }
       }

    //private void OnCollisionEnter(Collision collision)
   // {
    //    if (coroutineAllowed && collision.gameObject.CompareTag("Button"))
       // {
          //  string buttonName = collision.gameObject.name;
         //   if (buttonToWheelMap.ContainsKey(buttonName))
         //   {
         //       string wheelName = buttonToWheelMap[0][1];
       //         StartCoroutine(RotateWheel(wheelName));
     //       }
   //     }
 //   }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 3f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 9)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }
}
