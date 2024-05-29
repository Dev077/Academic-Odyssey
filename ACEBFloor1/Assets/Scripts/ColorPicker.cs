using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{

    public Material red, green, blue, purple, robot, white, brown, black, IM1, IM2;
   


    private void OnCollisionEnter(Collision collision)
    {
        Transform head = transform.Find("PlayerObj").Find("Head");
        Transform shoulders = transform.Find("PlayerObj").Find("Shoulders");
        Transform torso = transform.Find("PlayerObj").Find("Torso");
        Transform rightArm = transform.Find("PlayerObj").Find("RightArm");
        Transform leftArm = transform.Find("PlayerObj").Find("LeftArm");

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
            Globals.Instance.shouldersMat = red;
            Globals.Instance.rightarmMat = red;
            Globals.Instance.leftarmMat = red;
            Globals.Instance.torsoMat = red;
        }

        else if (collision.gameObject.tag == "Blue")
        {
            Torso.material = blue;
            Shoulders.material = blue;
            RightArm.material = blue;
            LeftArm.material = blue;
            Globals.Instance.shouldersMat = blue;
            Globals.Instance.rightarmMat = blue;
            Globals.Instance.leftarmMat = blue;
            Globals.Instance.torsoMat = blue;
        }

        else if (collision.gameObject.tag == "Green")
        {
            Torso.material = green;
            Shoulders.material = green;
            RightArm.material = green;
            LeftArm.material = green;
            Globals.Instance.shouldersMat = green;
            Globals.Instance.rightarmMat = green;
            Globals.Instance.leftarmMat = green;
            Globals.Instance.torsoMat = green;
        }

        else if (collision.gameObject.tag == "Purple")
        {
            Torso.material = purple;
            Shoulders.material = purple;
            RightArm.material = purple;
            LeftArm.material = purple;
            Globals.Instance.shouldersMat = purple;
            Globals.Instance.rightarmMat = purple;
            Globals.Instance.leftarmMat = purple;
            Globals.Instance.torsoMat = purple;
        }

        else if (collision.gameObject.tag == "Robot")
        {
            Head.material = robot;
            Globals.Instance.headMat = robot;
        }

        else if (collision.gameObject.tag == "White")
        {
            Head.material = white;
            Globals.Instance.headMat = white;
        }
        else if (collision.gameObject.tag == "Brown")
        {
            Head.material = brown;
            Globals.Instance.headMat = brown;
        }
        else if (collision.gameObject.tag == "Black")
        {
            Head.material = black;
            Globals.Instance.headMat = black;
        }
        else if (collision.gameObject.tag == "IronMan")
        {
            Head.material = IM1;
            Shoulders.material = IM2;
            Torso.material = IM1;
            LeftArm.material = IM2;
            RightArm.material = IM2;

            Globals.Instance.shouldersMat = IM2;
            Globals.Instance.rightarmMat = IM2;
            Globals.Instance.leftarmMat = IM2;
            Globals.Instance.torsoMat = IM1;
            Globals.Instance.headMat = IM1;

        }
    }
}