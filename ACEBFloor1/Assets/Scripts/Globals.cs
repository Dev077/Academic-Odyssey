using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public bool Level1BossComplete;
    public bool ballGameComplete;
    public Vector3 playerPosition;
    public bool Level2BossComplete;
    public Material headMat;
    public Material shouldersMat;
    public Material torsoMat;
    public Material leftarmMat;
    public Material rightarmMat;
    public bool OnFloor = true;
    public int clickCount = 0;
    public float currentHealth  = 100f;
    public float currentStrength = 100f;


    public static Globals Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Globals.Instance.currentHealth = 100f;
        Globals.Instance.currentStrength = 100f;
        Debug.Log("It works");
    }
}
