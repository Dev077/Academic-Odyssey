using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    public Button button;
    public GameObject panel;

    void Start()
    {
        button.onClick.AddListener(ShowRules);
        panel.SetActive(false);
    }
    void Update()
    {
        if (panel.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(
                button.GetComponent<RectTransform>(),
                Input.mousePosition,
                null))
            {
                CloseRules();
            }
        }
    }

    public void ShowRules()
    {
        panel.SetActive(true);
    }

    public void CloseRules()
    {
        panel.SetActive(false);
    }
}
