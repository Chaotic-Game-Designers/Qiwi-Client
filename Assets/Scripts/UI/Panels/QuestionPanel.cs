using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class QuestionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button[] answerButtons;
    //[SerializeField] private Image timerFill;
    [SerializeField] private TextMeshProUGUI timerText;

    [Inject] private IGameManager _gameManager;
    [Inject] private GameConfig _gameConfig;
    private float startTime;

    void Update()
    {
        var time = Math.Floor(_gameConfig.maxTimeToAnswer - Time.time + startTime);
        timerText.text = time.ToString();
        if (time == 0)
        {
            _gameManager.OnAnswerSelected(-1, _gameConfig.maxTimeToAnswer);
        }
    }

    public void Initialize(MusicQuestion question)
    {
        questionText.text = question.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            var index = i;
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text =
                question.possibleAnswers[i];
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }

        startTime = Time.time;

        //timerFill.DOFillAmount(0f, 10f)
        //    .SetEase(Ease.Linear);)
    }

    private void OnAnswerSelected(int index)
    {
        float timeToAnswer = Time.time - startTime;
        _gameManager.OnAnswerSelected(index, timeToAnswer);
    }
}