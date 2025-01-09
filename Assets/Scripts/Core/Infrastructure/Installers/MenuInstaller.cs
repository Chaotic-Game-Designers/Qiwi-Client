using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private MenuUIController menuUIController;
    [SerializeField] private MenuManager menuManager;

    public override void InstallBindings()
    {
        Container.Bind<MenuUIController>().FromInstance(menuUIController).AsSingle();
        Container.Bind<MenuManager>().FromInstance(menuManager).AsSingle();
    }
}