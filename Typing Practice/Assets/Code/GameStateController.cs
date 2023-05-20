using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public static event System.Action<GameState> OnStateChange;
    private GameState state = GameState.None;
    public GameState State
    {
        get => state;
        set { state = value;
            OnStateChange?.Invoke(state);
        }
    }
}
