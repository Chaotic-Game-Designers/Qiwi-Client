using UnityEngine;
using Zenject;
using System.Threading.Tasks;

public class GameInitializer : IInitializable
{
    private readonly IGameManager _gameManager;
    private readonly IGameAnalyticsService _gameAnalyticsService;

    [Inject]
    public GameInitializer(IGameManager gameManager, IGameAnalyticsService gameAnalyticsService)
    {
        _gameManager = gameManager;
        _gameAnalyticsService = gameAnalyticsService;
    }

    public async void Initialize()
    {
        await _gameManager.ShowLoading();
        await _gameAnalyticsService.Initialize();
        await _gameManager.StartGame(); 
    }
}
