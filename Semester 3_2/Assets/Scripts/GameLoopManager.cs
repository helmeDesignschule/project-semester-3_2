using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameLoopManager
{
    public enum GameState
    {
        MainMenu,
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

    public static void EnterMainMenu()
    {
        SceneManager.LoadScene(0);
        SetGameState(GameState.MainMenu);
    }
    
    public static void StartNewGame()
    {
        SceneManager.LoadScene(1);
        SetGameState(GameState.Playing);
    }
}
