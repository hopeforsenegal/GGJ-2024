using UnityEngine;
using UnityEngine.UI;

// We could populate these actions from the Config if we really wanted to
public static class Actions
{
    public static (float, float) Movement => (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    public static bool Shoot => Input.GetKeyDown(KeyCode.Space);

    // Take these out once we like the ending flow
    public static bool TestLose => Input.GetKey(KeyCode.Alpha1);
    public static bool TestWin => Input.GetKey(KeyCode.Alpha2);
}

public enum GameState
{
    Intro,
    RunningGame,
    JumpingGame,
    ShootingGame,
    Lose,
    Win
}


public class Game : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public Config config;

    [Header("UI")]
    public Image cutsceneImage;
    public Text cutsceneText;
    public Image winLoseScreen;

    private int cutsceneIndex;
    private float cutsceneTimer;
    private GameState gameState;

    protected void Start()
    {
        cutsceneImage.sprite = config.IntroRunningGame.screen;
        cutsceneTimer = config.IntroRunningGame.timePerText;
        winLoseScreen.enabled = false;
    }

    protected void Update()
    {
        // Test keys to get fedback quick
        if (Actions.TestLose) {
            winLoseScreen.enabled = true;
            winLoseScreen.sprite = config.LoseScreen;
        }
        if (Actions.TestWin) {
            winLoseScreen.enabled = true;
            winLoseScreen.sprite = config.WinScreen;
        }

        // Intro Screens
        if (Input.anyKeyDown || (cutsceneTimer -= Time.deltaTime) <= 0) {
            //if (cutsceneIndex < config.IntroRunningGame.Length - 1) {
            //    introImage.sprite = config.IntroScreens[cutsceneIndex + 1];
            //}

            //if (cutsceneIndex == config.IntroScreens.Length - 1) {
            //    gameState = GameState.RunningGame;
            //    introImage.enabled = false;
            //}
            //cutsceneTimer = config.timePerIntro;
            //cutsceneIndex += 1;
        }

        // Player

        // Player/Ski

        // Player/Jump

        // Player/Shooter

        // Enemies
    }
}
