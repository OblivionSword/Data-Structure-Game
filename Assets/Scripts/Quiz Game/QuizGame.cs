using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizGame : MonoBehaviour
{
    [SerializeField] QuizGameUI quizGameUI;
    [SerializeField] QuizGameScriptableObject questionCollection;
    private List<Question> questions;
    private Question selectedQuestion;

    // Start is called before the first frame update
    void Start()
    {
        questions = questionCollection.questions;
        SelectQuestion();
    }

    private void SelectQuestion()
    {
        int index = Random.Range(0, questions.Count);
        selectedQuestion = questions[index];
        quizGameUI.SetQuestion(selectedQuestion);
    }

    public bool Answer(string answer)
    {
        bool correctAnswer = false;

        //check answer from button/droped answer
        if (answer == selectedQuestion.correctAnswer)
        {
            //Correct
            correctAnswer = true;
            //set correct text promp to active
        }
        else
        {
            //False
            correctAnswer = false;
            //set false text promp to active
        }

        //TODO:
        //set state to ANSWERED
        //set selected question as answered (true)
        //set explanation text panel to active
        //set hint text to inactive
        //set hint button to inactive/uninteractable
        //set next button to active

        return correctAnswer;
    }

    public void NextQuestion()
    {
        //set state to QUESTION
        //set correct/false text promt to inactive
        //check if the next question is already answered if not use it
        //if all question has been answered go to end result screen
        SelectQuestion();
    }
    
}
