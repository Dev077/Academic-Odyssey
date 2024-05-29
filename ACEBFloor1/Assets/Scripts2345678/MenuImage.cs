using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuImage : MonoBehaviour
{
    public Sprite closeIcon;
    public Sprite menuIcon;
    public Button button;
    public Button resumeButton;
    public Button quitButton;
    public GameObject panel;
    [SerializeField] GameObject canvas1;

    private bool isMenuIcon = true; // Track the current state


    void Start()
    {
        Cursor.visible = false;
        button.onClick.AddListener(ChangeImage);
        panel.SetActive(false);
        resumeButton.onClick.AddListener(resume);
        quitButton.onClick.AddListener(exit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeImage(); // Call the xyz method
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ChangeImage()
    {
        if (isMenuIcon)
        {
            button.image.sprite = closeIcon;
            panel.SetActive(true);//shows menu
            Time.timeScale = 0;//resumes the game
            canvas1.SetActive(false);
        }
        else
        {
            button.image.sprite = menuIcon;
            panel.SetActive(false);//no menu
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            canvas1.SetActive(true);
            Time.timeScale = 1; // Pauses the game
        }
        isMenuIcon = !isMenuIcon;
    }

    public void showMenu()
    {
        panel.SetActive(true);
    }

    public void resume()
    {
        panel.SetActive(false);
        ChangeImage();
    }
    public void exit()
    {
        Application.Quit();
    }


}


