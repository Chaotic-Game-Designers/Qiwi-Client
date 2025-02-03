using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameConfig gameConfig;
    public override void InstallBindings()
    {
        Container.Bind<IAudioManager>().To<AudioManager>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
        Container.Bind<IGameAnalyticsService>().To<GameAnalyticsService>().AsSingle();
        Container.Bind<IQuestionRepository>().To<QuestionRepository>().AsSingle();
        Container.Bind<IScoreCalculator>().To<ScoreCalculator>().AsSingle();
        Container.Bind<IGameManager>().To<GameManager>().AsSingle();

        Container.BindInterfacesTo<GameInitializer>().AsSingle();
    }
}