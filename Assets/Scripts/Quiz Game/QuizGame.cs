using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour
{
    [SerializeField] QuizGameUI quizGameUI;
    [SerializeField] QuizGameScriptableObject questionCollection;
    //[SerializeField] Button nextButton;
    private List<Question> questions;
    private Question selectedQuestion;
    private int questionIndex;
    public QuizStateMachine state;

    // Start is called before the first frame update
    void Start()
    {
        questions = questionCollection.questions;
        questionIndex = 0;
        SelectQuestion();
    }

    private void SelectQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);
        /*
        if(questionIndex > questions.Count)
        {
            questionIndex = questions.Count - 1;
        }
        */

        selectedQuestion = questions[questionIndex];
        quizGameUI.SetQuestion(selectedQuestion);
        state = QuizStateMachine.QUESTION;
        //Debug.Log("question index= " + questionIndex);
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
        state = QuizStateMachine.ANSWERED;
        quizGameUI.SetNextButton(true);
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
        questionIndex += 1;
        EndQuiz();
        if(state != QuizStateMachine.END)
        {
            SelectQuestion();
            state = QuizStateMachine.QUESTION;
        }
        
    }

    public void EndQuiz()
    {
        if(questionIndex >= questions.Count)
        {
            questionIndex = questions.Count - 1;
            state = QuizStateMachine.END;
            Debug.Log("quiz is over");
        }
    }
    
}
