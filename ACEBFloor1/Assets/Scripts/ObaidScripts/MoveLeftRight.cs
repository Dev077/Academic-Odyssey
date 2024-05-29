using UnityEngine;
using System.Collections;

public class MoveLeftRight : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move
    public float moveSpeed; // Speed of movement

    private IEnumerator Start()
    {
        while (true) // Loop infinitely
        {
            yield return MoveObject(transform, transform.position + Vector3.left * moveDistance, moveSpeed); // Move left
            yield return MoveObject(transform, transform.position + Vector3.right * moveDistance, moveSpeed); // Move right
        }
    }

    IEnumerator MoveObject(Transform objectToMove, Vector3 endPosition, float speed)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = objectToMove.position;

        while (elapsedTime < speed)
        {
            objectToMove.position = Vector3.Lerp(startingPosition, endPosition, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.position = endPosition;
    }
}