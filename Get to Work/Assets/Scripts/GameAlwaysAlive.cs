using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    IntroRunningGame,
    RunningGame,
    IntroJumpingGame,
    JumpingGame,
    IntroShootingGame,
    ShootingGame,
    Win
}

// We could populate these actions from the Config if we really wanted to
public static class Actions
{
    public static bool Quit => Input.GetKeyDown(KeyCode.Escape);

    public static bool TestWin => Input.GetKey(KeyCode.Alpha1);
}

public static class GameAlwaysAlive
{
    public static GameState currentState;
    public static void TransitionTo(GameState gameState, Config config)
    {
        var scene = gameState switch
        {
            GameState.IntroRunningGame => config.cutsceneManagerScene,
            GameState.IntroJumpingGame => config.cutsceneManagerScene,
            GameState.IntroShootingGame => config.cutsceneManagerScene,
            GameState.Win => config.cutsceneManagerScene,
            GameState.RunningGame => config.RunningGame.levelToLoad,
            GameState.JumpingGame => config.JumpingGame.levelToLoad,
            GameState.ShootingGame => config.ShootingGame.levelToLoad,
            GameState.MainMenu => config.mainMenuScene,
            _ => throw new System.NotImplementedException(),
        };
        currentState = gameState;
        SceneManager.LoadScene(scene);
    }

    public static void DoUpdate(Config config)
    {
        if (Actions.Quit) {
            TransitionTo(GameState.MainMenu, config);
        }
        if (Actions.TestWin) {
            var newState = currentState switch
            {
                GameState.RunningGame => GameState.IntroJumpingGame,
                GameState.JumpingGame => GameState.IntroShootingGame,
                GameState.ShootingGame => GameState.Win,
                _ => throw new ArgumentOutOfRangeException($"{currentState}"),
            };
            TransitionTo(newState, config);
        }
    }
}
