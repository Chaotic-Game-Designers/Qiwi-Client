using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Infrastructure.Services
{
    public class AnswerScript : MonoBehaviour
    {

        public bool IsCorrectAnswer  = false;
        public QuizManager Manager;


        public void Answer()
        {
            if (IsCorrectAnswer)
            {
                Debug.Log("correct");
                Manager.Correct();
            }
            else
            {
                Debug.Log("incorrect");
                Manager.Wrong();
            }
        }
        
    }
}