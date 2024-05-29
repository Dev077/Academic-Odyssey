using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColourSequence : MonoBehaviour
{
    Renderer ren;
    private List<Color> sequence1;
    private List<Color> sequence2;
    private List<Color> sequence3;
    private List<Color> answer = new List<Color>();
    private bool enableGuessing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sequence1 = new List<Color> {Color.red, Color.blue, new Color(1.82f, 0.08f, 2.4f),Color.blue, Color.green, Color.red, new Color(1.82f, 0.08f, 2.4f)};
        ren = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StartColourSequenceStage1()
    {
        yield return new WaitForSeconds(1);
        foreach (Color colour in sequence1)
        {
            ren.material.color = colour;
            yield return new WaitForSeconds(1);
        }
        enableGuessing = true;


    }

    void OnMouseDown()
    {
        StartCoroutine(StartColourSequenceStage1());
    }

    public void AddColour(Color color)
    {
        answer.Add(color);
        Debug.Log("Color added: " + color);
        
    }

    public void SubmitColours()
    {
        Debug.Log("Temporary Colour Submission");
    }
}