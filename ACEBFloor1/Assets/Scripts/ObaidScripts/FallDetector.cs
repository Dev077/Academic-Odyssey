using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FallDetector : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad = "QuestionPopUp";
    public BrandNewPlayer brandNewPlayer;
    private int lives = 5;


    public TextMeshProUGUI score;

    void Start()
    {
        score.text = lives.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the trigger, loading scene: " + sceneNameToLoad);
            brandNewPlayer.MoveBigDabba();
            lives --;
            score.text = lives.ToString();

            if (lives == 0)
            {
                lives = 5;
                brandNewPlayer.MoveToBeginningPlane();
                score.text = lives.ToString();
            }

            // Load the specified scene
            //SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    public void ReturnToStart()
    {
        // Assuming 'startPosition' is the position where the player should return to.
        // This needs to be assigned, for example in Start(), or be a predefined Vector3.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            //player.transform.position = startPosition.position; // Replace with the actual start position
        }
        else
        {
            Debug.LogError("Player not found");
        }
    }

}
