using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    public bool dialogue = false;


    Vector3 moveDir;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Globals.Instance.OnFloor);
        Debug.Log(Globals.Instance.Level1BossComplete);
        if (Globals.Instance.Level1BossComplete == true && Globals.Instance.OnFloor == true)
        {
            Debug.Log("Made it");
            transform.position = new Vector3(17, 1, -104);
        }
        else
        {
            transform.position = new Vector3(-3, 2, -130);
        }

       
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Renderer Head = transform.Find("PlayerObj").Find("Head").GetComponent<Renderer>();
        Renderer Shoulders = transform.Find("PlayerObj").Find("Shoulders").GetComponent<Renderer>();
        Renderer Torso = transform.Find("PlayerObj").Find("Torso").GetComponent<Renderer>();
        Renderer RightArm = transform.Find("PlayerObj").Find("RightArm").GetComponent<Renderer>();
        Renderer LeftArm = transform.Find("PlayerObj").Find("LeftArm").GetComponent<Renderer>();

        Head.material = Globals.Instance.headMat;
        Shoulders.material = Globals.Instance.shouldersMat;
        Torso.material = Globals.Instance.torsoMat;
        RightArm.material = Globals.Instance.rightarmMat;
        LeftArm.material = Globals.Instance.leftarmMat;

        

    }

   



    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        
        MovePlayer();
       
        

    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calc movement direction
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDir.normalized*moveSpeed*10f,ForceMode.Force);
    }

    public void getPosition()
    {
        Globals.Instance.playerPosition = transform.position;
    }
   
}
