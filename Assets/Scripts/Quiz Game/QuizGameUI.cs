using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class QuizGameUI : MonoBehaviour, IDropHandler
{
    [SerializeField] QuizGame quizGame;
    [SerializeField] TextMeshProUGUI questionTextUI;
    [SerializeField] TextMeshProUGUI hintTextUI;
    [SerializeField] TextMeshProUGUI explanationTextUI;
    [SerializeField] GameObject visualPlaceholder;
    [SerializeField] Image questionImageUI;
    [SerializeField] UnityEngine.Video.VideoPlayer questionVideoUI;
    [SerializeField] List<Button> answerButtons;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject stackDragAnswer;
    [SerializeField] GameObject queueDragAnswer;
    public Vector2 stackAnswerDefaultPos;
    public Vector2 queueAnswerDefaultPos;

    private Question question;

    private void Awake()
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            Button button = answerButtons[i];
            button.onClick.AddListener(() => OnClick(button));
        }
    }
    private void Start()
    {
        stackAnswerDefaultPos = stackDragAnswer.transform.position;
        queueAnswerDefaultPos = queueDragAnswer.transform.position;
    }

    public void SetQuestion(Question question)
    {
        if (quizGame.state != QuizStateMachine.ANSWERED || quizGame.state != QuizStateMachine.END)
        {
            this.question = question;

            switch (question.questionType)
            {
                case QuestionType.TEXT:
                    visualPlaceholder.SetActive(false);
                    break;
                case QuestionType.IMAGE:
                    VisualHolder();
                    questionImageUI.gameObject.SetActive(true);

                    questionImageUI.sprite = question.questionImage;
                    break;
                case QuestionType.VIDEO:
                    VisualHolder();
                    questionVideoUI.gameObject.SetActive(true);

                    questionVideoUI.clip = question.questionVideo;
                    questionVideoUI.Play();
                    break;
            }

            questionTextUI.text = question.questionText;
            hintTextUI.text = question.hint;
            explanationTextUI.text = question.explanation;

        }
        
    }

    private void VisualHolder()
    {
        visualPlaceholder.SetActive(true);
        questionImageUI.gameObject.SetActive(false);
        questionVideoUI.gameObject.SetActive(false);
    }

    private void OnClick(Button button)
    {
        if (quizGame.state == QuizStateMachine.QUESTION)
        {
            bool checkAnswer = quizGame.Answer(button.name);

            if(checkAnswer == true)
            {
                Debug.Log("Correct answer");
            }
            else
            {
                Debug.Log("False answer");
            }
        }
    }

    public void ResetDragAnswerPosition()
    {
        stackDragAnswer.transform.position = stackAnswerDefaultPos;
        queueDragAnswer.transform.position = queueAnswerDefaultPos;
    }

    public void SetNextButton(bool val)
    {
        nextButton.SetActive(val);
    }

    public void SetExplanationText(bool val)
    {
        explanationTextUI.gameObject.SetActive(val);
    }

    public void SetHintText(bool val)
    {
        hintTextUI.gameObject.SetActive(val);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
    

}

