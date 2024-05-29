using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class TurnOnLaptop : MonoBehaviour
{


    private void OnMouseDown()
    {
        SceneManager.LoadScene("FinalBoss");

    }
}