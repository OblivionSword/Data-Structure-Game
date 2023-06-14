using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText;
    public QuestionType questionType;
    public Sprite questionImage;
    public UnityEngine.Video.VideoClip questionVideo;
    public string correctAnswer;
    public string hint;
    public string explanation;
    public bool answered;
}
