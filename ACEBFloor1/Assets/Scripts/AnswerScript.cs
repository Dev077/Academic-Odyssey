using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager quizManager;
    
    

    public void Answer()
    {

        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.sc++;
            quizManager.UpdateScore();
            quizManager.correct();
        }

        else
        {
            Debug.Log("Wrong Answer");
            quizManager.correct();
        }
    }

    
}
