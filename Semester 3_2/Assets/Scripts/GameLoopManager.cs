using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (newState == GameState.Playing)
        {
            Time.timeScale = 1;
        }
        else if (newState == GameState.GameOver)
        {
            Time.timeScale = 0;
        }
        
        if (onGameStateChange != null)
            onGameStateChange(state);
    }

    public static void StartNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetGameState(GameState.Playing);
    }
}
