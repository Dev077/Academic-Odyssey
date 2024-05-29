using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorSceneChange : MonoBehaviour
    

{

    [SerializeField] GameObject canvas1;
    void Start()
    {
      
    }


    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Globals.Instance.ballGameComplete == true && Globals.Instance.Level1BossComplete == true)
        {
            SceneManager.LoadScene("Floor2");
            Globals.Instance.OnFloor = false;
        }
        else if (collision.gameObject.CompareTag("Player") && Globals.Instance.ballGameComplete == false) 
        {
            canvas1.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Finish Level 1 Boss and 8 Ball Game First");
        }

    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
