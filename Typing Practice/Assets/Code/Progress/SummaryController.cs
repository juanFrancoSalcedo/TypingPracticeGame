using System;
using UnityEngine;
using Zenject;
using static ScoreController;

public class SummaryController : MonoBehaviour
{
    [SerializeField] KeyStack stack = null;
    [Inject]
    KeyboardDetector keyboardDetector = null;
    [Inject]
    ScoreController scoreController = null;
    [Inject]
    GameStateController stateController = null;

    [SerializeField] private SummaryView view = null;
    private Summary model = null;

    private void Awake()
    {
        model = new Summary(stack,keyboardDetector);
    }

    private void OnEnable() => KeyboardDetector.OnKeyPressed += CalculateChars;

    private void OnDisable() => KeyboardDetector.OnKeyPressed -= CalculateChars;

    private void CalculateChars(char arg1, bool arg2)
    {
        if (model.CalculateChars())
        {
            KeyboardDetector.OnKeyPressed -= CalculateChars;
            GameOver();
        }
    }

    public void GameOver() 
    {
        view.DisplaySummary();
        stateController.State = GameState.GameOver;
        model.SaveProgress(scoreController.Model);
    }

    [System.Serializable]
    private class SummaryView 
    {
        [SerializeField] private GameObject panel = null;

        public void DisplaySummary()
        {
            panel.SetActive(true);
        }
    }

    private class Summary
    {
        KeyStack stack = null;
        KeyboardDetector keyboardDetector = null;
        public Summary(KeyStack stack, KeyboardDetector keyboardDetector)
        {
            this.stack = stack;
            this.keyboardDetector = keyboardDetector;
        }

        public bool CalculateChars() => stack.Builder.ToString().Length > KeyboardDetector.Pool.LimitCharsToWin;

        public void SaveProgress(ScoreUpdater scoreUpdater)
        {

            keyboardDetector.Stop();
            if(scoreUpdater.ScoreIsSuccesfully())
            {
                CurrentProgress.CurrentProgressInstance.level++;
                PlayerProgressHandler.SaveProgress();
            }
        }
    }
}
