using UnityEngine;
using UnityEngine.EventSystems;

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
