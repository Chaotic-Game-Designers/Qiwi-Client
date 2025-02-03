using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionDatabase", menuName = "Qiwi/QuestionDatabase")]
public class QuestionDatabase : ScriptableObject
{
    public List<MusicQuestion> questions = new List<MusicQuestion>();
}