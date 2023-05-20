using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private ScoreUpdater model = null;
    public ScoreUpdater Model => model;
    [SerializeField] ScoreStorageView view = null;
    private void Awake() => model = new ScoreUpdater();

    private void OnEnable() => KeyboardDetector.OnKeyPressed += AddScore;

    private void OnDisable() => KeyboardDetector.OnKeyPressed -= AddScore;

    private void AddScore(char arg1, bool arg2)
    {
        model.AddScore(arg2);
        view.DisplayScore("Tu puntaje: "+model.Score.ToString());
        view.DisplayMisses("Errores: "+model.Misses.ToString());
    }

    [System.Serializable]
    public class ScoreStorageView
    {
        [SerializeField] private Text textHits = null;
        [SerializeField] private Text textMisses = null;
        [SerializeField] private Text textFinish = null;
        public void DisplayScore(string scoreText) => textFinish.text = textHits.text = scoreText;
        public void DisplayMisses(string scoreText) => textMisses.text = scoreText;
    }

    public class ScoreUpdater
    {
        private int score = 0;
        private int misses = 0;
        public int Score => score;
        public int Misses => misses;
        public void AddScore(bool arg2)
        {
            if (arg2)
                score++;
            else
                misses++;
        }

        public bool ScoreIsSuccesfully() 
        {
            return score > misses * 2;
        }
    }
}
