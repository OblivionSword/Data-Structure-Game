using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] QuizGame quizGame;
    [SerializeField] QuizGameUI quizGameUI;

    private GameObject nextButton;

    private void Awake()
    {
        nextButton = this.gameObject;
        Button button = nextButton.GetComponent<Button>();
        button.GetComponent<Button>().onClick.AddListener(() => OnClick(button));
    }

    private void Start()
    {
        nextButton.SetActive(false);
    }

    private void OnClick(Button button)
    {

    }
}
