using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1BossManager : MonoBehaviour
{
 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBoss()
    {
       
        Globals.Instance.Level1BossComplete = true;
        SceneManager.LoadScene("Level1Boss");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
 
    }
}
