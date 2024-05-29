using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    public Material red, green, blue, purple, robot, white, brown, black, IM1, IM2;


    private void OnCollisionEnter(Collision collision)
    {
        Transform head = transform.Find("Head");
        Transform shoulders = transform.Find("Shoulders");
        Transform torso = transform.Find("Torso");
        Transform rightArm = transform.Find("RightArm");
        Transform leftArm = transform.Find("LeftArm");

        Renderer Head = head.GetComponent<Renderer>();
        Renderer Shoulders = shoulders.GetComponent<Renderer>();
        Renderer Torso = torso.GetComponent<Renderer>();
        Renderer RightArm = rightArm.GetComponent<Renderer>();
        Renderer LeftArm = leftArm.GetComponent<Renderer>();

        if (collision.gameObject.tag == "Red")
        {
            Torso.material = red;
            Shoulders.material = red;
            RightArm.material = red;
            LeftArm.material = red;
        }

        else if (collision.gameObject.tag == "Blue")
        {
            Torso.material = blue;
            Shoulders.material = blue;
            RightArm.material = blue;
            LeftArm.material = blue;
        }

        else if (collision.gameObject.tag == "Green")
        {
            Torso.material = green;
            Shoulders.material = green;
            RightArm.material = green;
            LeftArm.material = green;
        }

        else if (collision.gameObject.tag == "Purple")
        {
            Torso.material = purple;
            Shoulders.material = purple;
            RightArm.material = purple;
            LeftArm.material = purple;
        }

        else if (collision.gameObject.tag == "Robot")
        {
            Head.material = robot;
        }

        else if (collision.gameObject.tag == "White")
        {
            Head.material = white;
        }
        else if (collision.gameObject.tag == "Brown")
        {
            Head.material = brown;
        }
        else if (collision.gameObject.tag == "Black")
        {
            Head.material = black;
        }
        else if (collision.gameObject.tag == "IronMan")
        {
            Head.material = IM1;
            Shoulders.material = IM2;
            Torso.material = IM1;
            LeftArm.material = IM2;
            RightArm.material = IM2;
        }


    }
}