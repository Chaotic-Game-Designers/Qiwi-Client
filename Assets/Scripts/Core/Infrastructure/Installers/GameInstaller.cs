using UnityEngine;
using Zenject;

public class GameInstaller : Installer<GameInstaller>
{
    [SerializeField] private SoundManager _soundManager;
    public override void InstallBindings()
    {
        Container.Bind<ISoundManager>().FromInstance(_soundManager).AsSingle();
    }
}