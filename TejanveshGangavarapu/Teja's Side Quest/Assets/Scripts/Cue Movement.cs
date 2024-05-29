using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CueMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5.0f;


    private Rigidbody attachedRigidbody;

    public void Awake()
    {
        attachedRigidbody = GetComponent<Rigidbody>();
        attachedRigidbody.isKinematic = true;
    }

    public void FixedUpdate()
    {
        if (Camera.main == null)
        {
            return;
        }

        if (!Input.GetMouseButton(0)) // 0 is the left mouse button
        {
            return;
        }

        Vector3 targetScreenPosition = Input.mousePosition;
        Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(
            new Vector3(targetScreenPosition.x, targetScreenPosition.y, Camera.main.transform.position.y - transform.position.y));

        Vector3 delta = targetWorldPosition - transform.position;

        delta.y = 0;

        float maxDist = Time.fixedDeltaTime * movementSpeed;
        delta = delta.normalized * Mathf.Min(delta.magnitude, maxDist);

        // Move our cue using the attached rigidbody
        attachedRigidbody.MovePosition(transform.position + delta);
    }
}