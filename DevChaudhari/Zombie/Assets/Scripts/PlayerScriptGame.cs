using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptGame : MonoBehaviour
{
    CharacterController controller;
    Vector3 movePos;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePos.x = Input.GetAxis("Vertical") * speed;
        movePos.z = Input.GetAxis("Horizontal") * speed;

        controller.Move(-movePos);

    }
}
