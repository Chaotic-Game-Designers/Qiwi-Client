using UnityEngine;
using GameAnaylics;

public interface IGameAnalyticsService
{
    void LogGameStart();
    void LogGameEnd(float score);
    void LogMenuOpen(string menuName);
    void LogButtonClick(string buttonName);
}

public class GameAnalyticsService : MonoBehaviour, IGameAnalyticsService
{
    private void Start()
    {
        GameAnalytics.Initialize();
    }

    public void LogGameStart()
    {
        GameAnalytics.NewProgressionEvent(
            GAProgressionStatus.Start,
            "game_start"
        );
    }

    public void LogGameEnd(float score)
    {
        GameAnalytics.NewProgressionEvent(
            GAProgressionStatus.Complete,
            "game_end",
            score
        );
    }

    public void LogMenuOpen(string menuName)
    {
        GameAnalytics.NewDesignEvent($"menu:open:{menuName}");
    }

    public void LogButtonClick(string buttonName)
    {
        GameAnalytics.NewDesignEvent($"button:click:{buttonName}");
    }
}