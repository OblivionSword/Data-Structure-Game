using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizGame : MonoBehaviour
{
    [SerializeField] QuizGameUI quizGameUI;
    [SerializeField] QuizGameScriptableObject questionCollection;
    public int score;
    public int maxScore;
    private List<Question> questions;
    private Question selectedQuestion;
    private int questionIndex;
    public QuizStateMachine state;

    // Start is called before the first frame update
    void Start()
    {
        questions = questionCollection.questions;
        questionIndex = 0;
        maxScore = questions.Count;
        SelectQuestion();
    }

    private void SelectQuestion()
    {
        int randomIndex = Random.Range(0, questions.Count);

        selectedQuestion = questions[questionIndex];
        quizGameUI.SetQuestion(selectedQuestion);
        state = QuizStateMachine.QUESTION;
    }

    public bool Answer(string answer)
    {
        bool correctAnswer = true;
        string questionAnswer = selectedQuestion.correctAnswer;

        //check answer from button/droped answer
        if (answer == questionAnswer)
        {
            //Correct
            correctAnswer = true;
            //set correct text promp to active
            score += 1;
            quizGameUI.SetCorrectPrompt(true);
        }
        else if(answer != questionAnswer)
        {
            //False
            correctAnswer = false;
            //set false text promp to active
            quizGameUI.SetFalsePrompt(true);
        }

        //TODO:
        //set state to ANSWERED
        //set explanation text panel to active
        //set hint text to inactive
        //set hint button to inactive/uninteractable
        //set next button to active
        state = QuizStateMachine.ANSWERED;
        quizGameUI.SetHintText(false);
        quizGameUI.SetHintButtonInteractive(false);
        quizGameUI.SetExplanationText(true);
        quizGameUI.SetNextButton(true);

        return correctAnswer;
    }

    public void NextQuestion()
    {
        //set state to QUESTION
        //set correct/false text promt to inactive
        //check if the next question is already answered if not use it
        //if all question has been answered go to end result screen
        questionIndex += 1;
        if(questionIndex >= questions.Count)
        {
            state = QuizStateMachine.END;
        }

        quizGameUI.SetCorrectPrompt(false);
        quizGameUI.SetFalsePrompt(false);

        if(state != QuizStateMachine.END)
        {
            SelectQuestion();
        }else if (state == QuizStateMachine.END)
        {
            EndQuiz();
        }
        
    }

    public void EndQuiz()
    {
        if(questionIndex >= questions.Count)
        {
            questionIndex = questions.Count - 1;
            quizGameUI.setEndResultScreen(true);
            Debug.Log("quiz is over");
        }
    }

    public void QuitQuiz()
    {
        SceneManager.LoadScene("Main Menu");
    }
    
}
