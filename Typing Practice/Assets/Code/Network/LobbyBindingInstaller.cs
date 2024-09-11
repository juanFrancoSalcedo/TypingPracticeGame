using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LobbyBindingInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<NetworkRunnerController>().FromInstance(NetworkRunnerController.Instance).AsSingle();
    }
}
