using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    CharacterController controller;
    Vector3 movePos;
    private float moveSpeed = 20f;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position; // Store the starting position

    }

    // Update is called once per frame
    void Update()
    {
        movePos.x = Input.GetAxis("Horizontal") * moveSpeed;
        movePos.z = Input.GetAxis("Vertical") * moveSpeed;
        movePos.y = 0;

        controller.Move(movePos * Time.deltaTime);

        // After moving, reset the Y position to the original starting Y position
        Vector3 currentPosition = transform.position;
        currentPosition.z = Mathf.Clamp(currentPosition.z, -7, -5.5f);//limiting the ball movement on z-axis
        currentPosition.x = Mathf.Clamp(currentPosition.x, -7.5f, 7.5f);//limiting the ball movement on x-axis
        currentPosition.y = Mathf.Clamp(currentPosition.y, 0.25f, 0.25f);//limiting the ball movement on y-axis
        transform.position = currentPosition;

        if (Input.GetKeyDown(KeyCode.R))
        {
            resetBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cue")
        {
            //add code
        }
        if (collision.gameObject.tag == "coin")
        {
           Destroy(collision.gameObject);
            resetBall();

        }
    
    }

    private void resetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        controller.enabled = false;
        transform.position = startPosition;
        controller.enabled = true;
    }

}
