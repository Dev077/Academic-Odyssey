using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private float moveSpeed = 3f;
    //public bool ballGameComplete = false;
    private int coinHitCounter = 0;
    public BallCameraChanger ballCameraChanger;
    //[SerializeField] Globals ballGame;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Use physics-based movement instead of CharacterController
        //float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        //float moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision with {collision.gameObject.tag}");
        // Collision handling remains the same
        if (collision.gameObject.tag == "cue")
        {
            Vector3 forceDirection = collision.contacts[0].normal;
            rb.AddForce(-forceDirection * moveSpeed, ForceMode.Impulse);
        }
        else if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            Debug.Log("Resetting Ball");
            ResetBall();
            coinHitCounter++;
            
            if (coinHitCounter == 3) {
                Globals.Instance.ballGameComplete = true;
                Debug.Log("True");
                ballCameraChanger.EndGame();
            }
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("Resetting Ball");
            ResetBall();
        }
    }

    private void ResetBall()
    {
        // Reset the ball's position and physics
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
