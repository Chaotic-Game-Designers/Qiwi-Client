public class GameState
{
    public float CurrentScore { get; private set; }
    public bool IsGamePaused { get; private set; }

    public void UpdateScore(float newScore)
    {
        CurrentScore = newScore;
    }

    public void TogglePause()
    {
        IsGamePaused = !IsGamePaused;
    }
}