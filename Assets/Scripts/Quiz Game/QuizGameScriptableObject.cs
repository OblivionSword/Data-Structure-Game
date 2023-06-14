using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionCollection", menuName = "QuestionCollection")]
public class QuizGameScriptableObject : ScriptableObject
{
    public List<Question> questions;
}
