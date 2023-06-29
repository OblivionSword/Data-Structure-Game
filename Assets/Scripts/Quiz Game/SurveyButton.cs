using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurveyButton : MonoBehaviour
{
    private Button surveyButton;

    private void Start()
    {
        surveyButton = GetComponent<Button>();
        surveyButton.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        Application.OpenURL("https://forms.gle/kRzrAPPkKjuQiiBf7");
    }
}
