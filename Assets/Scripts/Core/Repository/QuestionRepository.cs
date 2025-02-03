using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class QuestionRepository : IQuestionRepository
{
    private List<MusicQuestion> _questions = new List<MusicQuestion>();
    private readonly GameConfig _gameConfig;
    private System.Random _random = new System.Random();

    [Inject]
    public QuestionRepository(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public async Task InitializeQuestions()
    {
        await Task.Yield();

        var questionDatabase = Resources.Load<QuestionDatabase>("Questions/QuestionDatabase");
        if (questionDatabase != null)
        {
            _questions = questionDatabase.questions;
        }
        else
        {
            Debug.LogError("QuestionDatabase not found in Resources folder!");
        }

        await Task.Delay(100);
    }

    public MusicQuestion GetRandomQuestion()
    {
        if (_questions == null || _questions.Count == 0)
        {
            Debug.LogError("No questions available!");
            return null;
        }

        int randomIndex = _random.Next(_questions.Count);
        return _questions[randomIndex];
    }

    public List<MusicQuestion> GetAllQuestions()
    {
        return _questions;
    }
}
