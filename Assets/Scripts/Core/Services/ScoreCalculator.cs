using UnityEngine;
using Zenject;

public class ScoreCalculator : IScoreCalculator
{
    private readonly GameConfig _gameConfig;

    [Inject]
    public ScoreCalculator(GameConfig gameConfig)
    {
        _gameConfig = gameConfig;
    }

    public int CalculateScore(bool isCorrect, float timeToAnswer)
    {
        if (!isCorrect) return 0;

        float timeRatio = 1 - (timeToAnswer / _gameConfig.maxTimeToAnswer);
        return Mathf.RoundToInt(100 * Mathf.Max(0, timeRatio));
    }
}