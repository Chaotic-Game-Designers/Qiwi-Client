using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameAnalyticsService analyticsService;

    public override void InstallBindings()
    {
        Container.Bind<ISoundManager>().FromInstance(soundManager).AsSingle();
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
        Container.Bind<IGameAnalyticsService>().FromInstance(analyticsService).AsSingle();

        // Bind other game-specific services
        Container.Bind<GameState>().AsSingle();
    }
}