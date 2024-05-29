using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ColourSequence : MonoBehaviour
{
    Renderer ren;
    public GameObject thirdPersoncam;
    public GameObject bossView;
    private List<Color> sequence1;
    private List<Color> sequence2;
    private List<Color> sequence3;
    private List<string> sequenceCheck1;
    private List<string> sequenceCheck2;
    private List<string> sequenceCheck3;
    private List<string> answer = new List<string>();
    private bool enableGuessing = false;
    private bool level1 = true;
    private bool level2 = false;
    private bool level3 = false;

    [SerializeField] GameObject correct;
    [SerializeField] GameObject wrong;
    [SerializeField] GameObject wait;
    

    // Start is called before the first frame update
    void Start()
    {
        
        sequence1 = new List<Color> { new Color(0f, 0f, 2.55f), new Color(2.55f, 0f, 0f), new Color(0f, 0f, 2.55f),
            new Color(0f, 2.55f, 0f)  };

        sequence2 = new List<Color> { new Color(2.55f, 0f, 0f), new Color(0f, 0f, 2.55f), 
            new Color(1.82f, 0.08f, 2.4f), new Color(0f, 0f, 2.55f), new Color(0f, 2.55f, 0f), 
            new Color(2.55f, 0f, 0f), new Color(1.82f, 0.08f, 2.4f)};

        sequence3 = new List<Color> { new Color(0f, 0f, 2.55f), new Color(0f, 2.55f, 0f), new Color(2.55f, 0f, 0f),
            new Color(1.82f, 0.08f, 2.4f), new Color(2.55f, 0f, 0f), new Color(1.82f, 0.08f, 2.4f), new Color(2.55f, 0f, 0f)  };



        sequenceCheck1 = new List<string> {"Blue", "Red","Blue","Green"};
        sequenceCheck2 = new List<string> {"Red","Blue","Pink","Blue","Green","Red","Pink" };
        sequenceCheck3 = new List<string> { "Blue", "Green","Red","Pink", "Red","Pink","Red"};



        ren = GetComponent<Renderer>();
        ren.material.color = new Color(0.3f, 0.3f, 0.3f);

        bossView.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator StartColourSequenceStage1()
    {
        
        yield return new WaitForSeconds(1.3f);
        foreach (Color colour in sequence1)
        {
            ren.material.color = colour;
            yield return new WaitForSeconds(1.3f);
        }
        ren.material.color = new Color(0.3f, 0.3f, 0.3f);
        enableGuessing = true;
    }

    private IEnumerator StartColourSequenceStage2()
    {
        yield return new WaitForSeconds(2f);
        foreach (Color colour in sequence2)
        {
            ren.material.color = colour;
            yield return new WaitForSeconds(1f);
        }
        ren.material.color = new Color(0.3f, 0.3f, 0.3f);
        enableGuessing = true;
    }

    private IEnumerator StartColourSequenceStage3()
    {
        yield return new WaitForSeconds(2f);
        foreach (Color colour in sequence3)
        {
            ren.material.color = colour;
            yield return new WaitForSeconds(0.6f);
        }
        ren.material.color = new Color(0.3f, 0.3f, 0.3f);
        enableGuessing = true;
    }

    void OnMouseDown()
    {
        if (level1)
        {
            StartCoroutine(StartColourSequenceStage1());
        }
        else if(level2)
        {
            StartCoroutine(StartColourSequenceStage2());
        }
        else if (level3)
        {
            StartCoroutine(StartColourSequenceStage3());
        }   
    }

    public void AddColour(string color)
    {
        if (enableGuessing)
        { 
            answer.Add(color);
        }

        else 
        {
            wait.SetActive(true);
            Debug.Log("Wait for sequence to finish before guessing");
        }
        
    }

    public void SubmitColours()
    {
        if (enableGuessing)
        {
            if (answer.SequenceEqual(sequenceCheck1))
            {
                correct.SetActive(true);
                Debug.Log("Correct!!");
                enableGuessing = false;
                level2 = true;
                level1 = false;
                answer.Clear();
            }
            else if (answer.SequenceEqual(sequenceCheck2))
            {
                correct.SetActive(true);
                Debug.Log("Correct!!");
                enableGuessing = false;
                level3 = true;
                level1 = false;
                level2 = false;
                answer.Clear();
            }
            else if (answer.SequenceEqual(sequenceCheck3))
            {
                correct.SetActive(true);
                Debug.Log("Correct!!");
                enableGuessing = false;
                answer.Clear();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                thirdPersoncam.SetActive(true);
                bossView.SetActive(false);
                Globals.Instance.Level2BossComplete = true;

            }
            else
            {
                wrong.SetActive(true);
                Debug.Log("Incorrect Try Again!");
                answer.Clear();
            }
        }

        else
        {
            wait.SetActive(true);
            Debug.Log("Watch the Sequence first");
        }
        
    }
}