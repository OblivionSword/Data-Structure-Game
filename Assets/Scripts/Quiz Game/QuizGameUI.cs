using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizGameUI : MonoBehaviour
{
    [SerializeField] QuizGame quizGame;
    [SerializeField] TextMeshProUGUI questionTextUI;
    [SerializeField] TextMeshProUGUI hintTextUI;
    [SerializeField] TextMeshProUGUI explanationTextUI;
    [SerializeField] GameObject visualPlaceholder;
    [SerializeField] Image questionImageUI;
    [SerializeField] UnityEngine.Video.VideoPlayer questionVideoUI;
    [SerializeField] List<Button> answerButtons;

    private Question question;
    private bool answered;

    private void Awake()
    {
        for (int i = 0; i < answerButtons.Count; i++)
        {
            Button button = answerButtons[i];
            button.onClick.AddListener(() => OnClick(button));
        }
    }

    public void SetQuestion(Question question)
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

        answered = false;
    }

    private void VisualHolder()
    {
        visualPlaceholder.SetActive(true);
        questionImageUI.gameObject.SetActive(false);
        questionVideoUI.gameObject.SetActive(false);
    }

    private void OnClick(Button button)
    {
        if (!answered)
        {
            answered = true;
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

}
