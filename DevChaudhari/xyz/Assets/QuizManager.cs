using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public int sc = 0;
    public List<QuestionsandAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text score;

    public TMP_Text Questiontxt;

    private void Start()
    {
        generateQuestion();
    }

    public void correct()
    {
        try
        {
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }
        catch (System.ArgumentOutOfRangeException ex)
        {
            if (sc < 7)
            {
                RestartGame();
            }
            else
            {
                QuitGame();
            }
            
        }
    }

    void SetAnswers()
    {
        
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

                if (QnA[currentQuestion].CorrectAnswer == i + 1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;

                }
            }
        
        
        
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        Questiontxt.text = QnA[currentQuestion].Questions;
        SetAnswers();
    }

    public void UpdateScore()
    {
        score.text = $"Score: {sc}";
    }

    public void QuitGame()
    {
        // !WARNING!: the below commented part is to quit the game entirly and is ony if we decide to do it. If we do it, we have to change the bool to void
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif


    }


    public void RestartGame()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }

   



}
