using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public GameObject questionCanvas; // inspector
    public Transform startPoint; // starting plane transform in the inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // player GameObject has the needs a tag
        {
            questionCanvas.SetActive(true); // Show the question canvas
            // Disable player movement 
        }
    }

    public void ReturnToStart()
    {
        var player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = startPoint.position; // Teleport the player to the start
        // Enable player movement here if it was previously disabled
    }
}
