using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public GameObject thirdPersoncam;
    public GameObject bossView;

    // Start is called before the first frame update
    void Start()
    {
        bossView.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        thirdPersoncam.SetActive(false);
        bossView.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
