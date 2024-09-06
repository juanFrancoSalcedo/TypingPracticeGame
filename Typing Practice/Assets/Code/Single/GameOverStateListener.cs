using System;
using UnityEngine;
using Zenject;

public class GameOverStateListener : MonoBehaviour
{
    [Inject]
    GameStateController stateController;
    [Inject]
    KeyboardDetector keyDetector;
    [SerializeField] TimerController timerController = null;

    private void OnEnable() => GameStateController.OnStateChange += CheckStopDetector;

    private void OnDisable() => GameStateController.OnStateChange -= CheckStopDetector;

    private void CheckStopDetector(GameState obj)
    {
        if (obj == GameState.GameOver)
        {
            keyDetector.Stop();
            timerController.StopTimer();
        }
    }
}