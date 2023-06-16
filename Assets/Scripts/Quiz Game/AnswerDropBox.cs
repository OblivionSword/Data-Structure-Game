using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnswerDropBox : MonoBehaviour, IDropHandler
{
    [SerializeField] QuizGame quizGame;
    [SerializeField] QuizGameUI quizGameUI;

    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            if (quizGame.state == QuizStateMachine.QUESTION)
            {
                string answer = eventData.pointerDrag.name;
                bool checkAnswer = quizGame.Answer(answer);
                //quizGameUI.SetNextButton(true);

                if (checkAnswer == true)
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
}
