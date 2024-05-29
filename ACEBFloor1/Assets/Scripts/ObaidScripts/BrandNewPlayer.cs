using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class BrandNewPlayer : MonoBehaviour
{

    public List<Transform> steps;
    //private Transform startingPosition;
    private int currentStepIndex;
    public static int lastStep = -1;
    private Vector3 startPosition = new Vector3(-1,0,-5);

    void Start()
    {

        // Assuming the first step is the starting position
        //startingPosition = steps[0];
        // MoveToStartingPosition();
        MoveToBeginningPlane();

        //PlayerPrefs.SetInt("LastStepIndex", 0);

        //if (!PlayerPrefs.HasKey("LastStepIndex"))
        //{
        //    // This will only set the index to 0 if it doesn't already exist,

        //    PlayerPrefs.Save();
        //}
    }

    void Awake()
    {
        // Initialize the list
        steps = new List<Transform>();



        // Get all GameObjects with the "Step" tag
        var stepGameObjects = GameObject.FindGameObjectsWithTag("Step");

        // Filter out any GameObjects that don't have a number in their name
        var filteredStepGameObjects = stepGameObjects.Where(go => TryParseNumberFromName(go.name, out _)).ToList();

        // Order the remaining steps by the parsed number
        steps.AddRange(filteredStepGameObjects.OrderBy(go =>
        {
            TryParseNumberFromName(go.name, out int number);
            return number;
        }).Select(go => go.transform));

 
    }


    private bool TryParseNumberFromName(string name, out int number)
    {
        // Match only the number at the end of the name, surrounded by parentheses
        var match = System.Text.RegularExpressions.Regex.Match(name, @"\((\d+)\)$");
        if (match.Success && int.TryParse(match.Groups[1].Value, out number))
        {
            return true;
        }
        number = 0;
        return false;
    }


    public void MoveToStartingPosition()
    {
        transform.position = startPosition;
        lastStep = -1;
        Debug.Log("Player moved to starting position on the original plane.");
    }

    public void MoveToBeginningPlane()
    {
        // Find the GameObject with the "BeginningPlane" tag.
        GameObject beginningPlane = GameObject.FindGameObjectWithTag("BeginningPlane");
        lastStep = -1;

        // Check if the beginningPlane was found
        if (beginningPlane != null)
        {
            // Move the player to the position of the beginning plane
            transform.position = beginningPlane.transform.position;
            currentStepIndex = 0; // Reset the step index if you're using it
            Debug.Log("Player moved to Beginning Plane.");
        }
        else
        {
            Debug.LogError("The Beginning Plane was not found in the scene.");
        }
    }


    // figure out what step it's on
    public void SetCurrentStep(int stepIndex)
    {
        currentStepIndex = stepIndex;
        lastStep = stepIndex; // Update the lastStep static variable
        PlayerPrefs.SetInt("LastStepIndex", stepIndex);
        PlayerPrefs.Save(); // Save the PlayerPrefs after setting the value
        Debug.Log("Current step set to: " + steps[currentStepIndex].name);
    }



    //this is the method to get all the elements 
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a step
        if (collision.gameObject.CompareTag("Step"))
        {

            string number = collision.gameObject.name;
            Debug.Log(number);
            char num = number[7];

            if (num == '1')
            {
                if (number[8] == '0')
                {
                    SetCurrentStep(10);
                    lastStep = 10;
                }

                else if (number[8] == '1')
                {
                    SetCurrentStep(11);
                    lastStep = 11;
                }

                else
                {
                    SetCurrentStep(1);
                    lastStep = 1;
                }
            }

            else
            {
                int myInt = num - '0';
                SetCurrentStep(myInt);
                lastStep = myInt;
            }

        }

    }



    public void MoveBigDabba()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        int savedStepIndex = PlayerPrefs.GetInt("LastStepIndex", -1); // Use a default value of -1

        if (lastStep >= 0 && lastStep < steps.Count)
        {
            Vector3 newPosition = steps[savedStepIndex].position;
            newPosition.y += 0.5f;

            if (rb.isKinematic)
            {
                rb.transform.position = newPosition;
            }
            else
            {
                rb.MovePosition(newPosition);
            }
            currentStepIndex = savedStepIndex;
            Debug.Log("Player moved to saved step: " + steps[savedStepIndex].name);
        }
        else
        {
            Debug.LogError("Saved step index is out of range or not set. Moving to default position.");
            // Move to a default position or the first step as a fallback
            //rb.transform.position = startPosition; // Or any other default position you have
            MoveToBeginningPlane();
        }
    }


    //public void MoveBigDabba()
    //{
    //    Rigidbody rb = GetComponent<Rigidbody>();
    //    int savedStepIndex = PlayerPrefs.GetInt("LastStepIndex", 0); // Use a default value of 0 to start at the beginning

    //    if (savedStepIndex < steps.Count)
    //    {
    //        Vector3 newPosition = steps[savedStepIndex].position;
    //        MovePlayer(rb, newPosition);
    //        currentStepIndex = savedStepIndex;
    //        Debug.Log("Player moved to saved step: " + steps[savedStepIndex].name);
    //    }
    //    else
    //    {
    //        Debug.LogError("Saved step index is out of range.");
    //        // If you want to handle out-of-range indices, do it here
    //    }
    //}



    //private void MovePlayer(Rigidbody rb, Vector3 newPosition)
    //{
    //    if (rb.isKinematic)
    //    {
    //        rb.transform.position = newPosition;
    //    }
    //    else
    //    {
    //        rb.MovePosition(newPosition);
    //    }
    //}



}

