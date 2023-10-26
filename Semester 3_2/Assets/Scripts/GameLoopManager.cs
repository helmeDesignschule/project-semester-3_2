using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLoopManager
{
    public enum GameState
    {
        Playing,
        GameOver
    }

    private static GameState state = GameState.Playing;
    public static event Action<GameState> onGameStateChange;

    public static GameState GetGameState()
    {
        return state;
    }

    public static void SetGameState(GameState newState)
    {
        state = newState;
        if (onGameStateChange != null)
            onGameStateChange(state);
    }
}
