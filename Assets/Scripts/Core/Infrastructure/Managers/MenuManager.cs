using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuManager : MonoBehaviour
{
    private IGameAnalyticsService _analyticsService;
    private ISoundManager _soundManager;

    [Inject]
    private void Construct(
        IGameAnalyticsService analyticsService,
        ISoundManager soundManager)
    {
        _analyticsService = analyticsService;
        _soundManager = soundManager;
    }

    public void StartGame()
    {
        _analyticsService.LogGameStart();
        SceneManager.LoadScene("GameScene"); // Make sure to set up your scene name
    }
}