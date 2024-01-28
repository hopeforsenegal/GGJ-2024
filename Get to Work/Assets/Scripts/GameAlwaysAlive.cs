using UnityEngine.SceneManagement;

public enum GameState
{
    IntroRunningGame,
    RunningGame,
    IntroJumpingGame,
    JumpingGame,
    IntroShootingGame,
    ShootingGame,
    Lose,
    Win
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
            GameState.Lose => config.cutsceneManagerScene,
            GameState.Win => config.cutsceneManagerScene,
            GameState.RunningGame => config.RunningGame.nextLevel,
            GameState.JumpingGame => config.JumpingGame.nextLevel,
            GameState.ShootingGame => config.ShootingGame.nextLevel,
            _ => throw new System.NotImplementedException(),
        };
        currentState = gameState;
        SceneManager.LoadScene(scene);
    }
}
