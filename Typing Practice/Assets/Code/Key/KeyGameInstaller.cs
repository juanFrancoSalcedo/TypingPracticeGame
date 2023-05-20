using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyGameInstaller : MonoInstaller
{
    [SerializeField] KeyboardDetector detector;
    [SerializeField] GameStateController stateController;
    [SerializeField] ScoreController scoreController;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<KeyboardDetector>().FromInstance(detector).AsSingle();
        Container.BindInterfacesAndSelfTo<GameStateController>().FromInstance(stateController).AsSingle();
        Container.BindInterfacesAndSelfTo<ScoreController>().FromInstance(scoreController).AsSingle();
    }
}
