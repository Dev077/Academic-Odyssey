using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorFloor3 : MonoBehaviour
{
    [SerializeField] GameObject canvas1;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && Globals.Instance.Level2BossComplete == true)
        {

            SceneManager.LoadScene("Stairs");
        }
        else
        {
            canvas1.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Finish Boss 2");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
