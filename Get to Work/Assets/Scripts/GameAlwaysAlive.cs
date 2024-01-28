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

public static class Actions
{
    public static bool Quit => Input.GetKeyDown(KeyCode.Escape);
    public static bool TestWin => Input.GetKey(KeyCode.Alpha1);
}

public class GameAlwaysAlive : MonoBehaviour
{
    // Singleton
    public static GameAlwaysAlive Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    public Config config;
    public AudioSource music;
    public AudioSource sfx;

    public GameState currentState;
    public float runningTime;

    protected void Start()
    {
        music.clip = config.MenuMusic;
        music.Play();
    }

    protected void Update()
    {
        if (Actions.Quit) {
            TransitionTo(GameState.MainMenu);
        }
#if UNITY_EDITOR
        if (Actions.TestWin) {
            var newState = currentState switch
            {
                GameState.RunningGame => GameState.IntroJumpingGame,
                GameState.JumpingGame => GameState.IntroShootingGame,
                GameState.ShootingGame => GameState.Win,
                _ => throw new ArgumentOutOfRangeException($"{currentState}"),
            };
            TransitionTo(newState);
        }
#endif
    }

    public void TransitionTo(GameState gameState)
    {
        // Choose scene
        var scene = gameState switch
        {
            GameState.IntroRunningGame => config.cutsceneManagerScene,
            GameState.IntroJumpingGame => config.cutsceneManagerScene,
            GameState.IntroShootingGame => config.cutsceneManagerScene,
            GameState.Win => config.winScene,
            GameState.RunningGame => config.RunningGame.levelToLoad,
            GameState.JumpingGame => config.JumpingGame.levelToLoad,
            GameState.ShootingGame => config.ShootingGame.levelToLoad,
            GameState.MainMenu => config.mainMenuScene,
            _ => throw new System.NotImplementedException(),
        };

        // Play right music track
        var musicTrack = gameState switch
        {
            GameState.IntroRunningGame => config.RunMusic,
            GameState.RunningGame => config.RunMusic,
            GameState.IntroJumpingGame => config.JumpMusic,
            GameState.JumpingGame => config.JumpMusic,
            GameState.IntroShootingGame => config.ShootMusic,
            GameState.ShootingGame => config.ShootMusic,
            GameState.Win => config.MenuMusic,
            GameState.MainMenu => config.MenuMusic,
            _ => throw new NotImplementedException(),
        };
        if (music.clip != musicTrack) {
            music.clip = musicTrack;
            music.Play();
        }

        if (currentState == GameState.MainMenu) {
            Debug.Log("Reset the time");
            runningTime = 0;
        }

        currentState = gameState;
        SceneManager.LoadScene(scene);
    }

    internal void PlayDeath()
    {
        sfx.clip = config.DeathSFX;
        sfx.Play();
    }
}
