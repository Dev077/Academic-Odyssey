using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionandAnswers> QnA;
    public GameObject[] options;
    public int currentQuestions;
    public Text questionText;
    public FallDetector fallDetector;
    public GameObject quizCanvas;

    public void Start()
    {
        quizCanvas.SetActive(false);
        generateQuestion();
    }

    public void correct()
    {
        QnA.RemoveAt(currentQuestions);
        generateQuestion();
    }

    void generateQuestion()
    {
        currentQuestions = Random.Range(0, QnA.Count);
        questionText.text = QnA[currentQuestions].Question;
        setAnswers();

        QnA.RemoveAt(currentQuestions);
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestions].Answer[i];
            options[i].GetComponent<AnswerScript>().isCorrect = false;

            if (QnA[currentQuestions].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void wrong()
    {
        // Call this method when a wrong answer is selected.
        quizCanvas.SetActive(false);
        fallDetector.ReturnToStart();
        generateQuestion();
    }

    public void ShowQuestion()
    {
        generateQuestion();
        quizCanvas.SetActive(true);
    }

}
