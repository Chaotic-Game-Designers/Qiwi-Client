using Assets.Scripts.Core.Infrastructure.Models;
using Assets.Scripts.Core.Infrastructure.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public GameObject[] options;

    public List<Test> QA;
    public int CurrentQuestion; 
    public Text QuestionText;

    public GameObject Quiz;
    public GameObject GameOverMenu;

    public Text ScoreText;
    public int TotalQuestions;
    public int TotalScore;


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        TotalQuestions = QA.Count;
        GameOverMenu.SetActive(false);
        generateQuestion();
    }

    public void Correct()
    {
        TotalScore += 1;
        QA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }

    public void Wrong()
    {
        QA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }

    void GameOver()
    {
        Quiz.SetActive(false);
        GameOverMenu.SetActive(true);
        ScoreText.text = $"{TotalScore}/{TotalQuestions}";
    }

    

    void generateQuestion()
    {
        if (QA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QA.Count);

            QuestionText.text = QA[CurrentQuestion].Question;

            generateAnswers();
        }
        else
        {
            Debug.Log("questions finished");
            GameOver();
        }

        
    }

    void generateAnswers()
    {
        for(int i = 0; i < options.Length; i++) 
        {
            options[i].GetComponent<AnswerScript>().IsCorrectAnswer = false;

            var value = QA[CurrentQuestion].Answers[i];
            options[i].transform.GetChild(0).GetComponent<Text>().text = value;

            //set correct value for nex time
            if (QA[CurrentQuestion].CorrectAnswer == i+1)
                options[i].GetComponent<AnswerScript>().IsCorrectAnswer =true;
        }
    }

}
