using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraChanger : MonoBehaviour
{
    
    public GameObject BallCamera;
    public GameObject thirdPersonCam;
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject cue;
    //[SerializeField] Globals Level1Boss;


    // Start is called before the first frame update
    void Start()
    {
      BallCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log(Globals.Instance.Level1BossComplete);
        if (Globals.Instance.Level1BossComplete == true)
        {
            thirdPersonCam.SetActive(false);
            BallCamera.SetActive(true);
            Cursor.visible = true;
            cue.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            canvas1.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
        }

    }

    public void EndGame()
    {
        thirdPersonCam.SetActive(true);
        BallCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
