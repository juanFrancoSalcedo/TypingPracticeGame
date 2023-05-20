using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyPool 
{
    public List<KeyCode> keysPool = new List<KeyCode>();
    [field: SerializeField] public int LimitCharsToWin { get; private set; } = 6;

    [SerializeField] private Progress progress = null;
    public Progress Progress => progress;
}
