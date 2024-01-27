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
    Game,
    Lose,
    Win
}


public class Game : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public Config config;

    [Header("UI")]
    public Image introImage;
    public Image winLoseScreen;

    private int currentIndex;
    private float introTimer;
    private GameState gameState;

    protected void Start()
    {
        introImage.sprite = config.IntroScreens[currentIndex];
        introTimer = config.timePerIntro;
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
        if (Input.anyKeyDown || (introTimer -= Time.deltaTime) <= 0) {
            if (currentIndex < config.IntroScreens.Length - 1) {
                introImage.sprite = config.IntroScreens[currentIndex + 1];
            }

            if (currentIndex == config.IntroScreens.Length - 1) {
                gameState = GameState.Game;
                introImage.enabled = false;
            }
            introTimer = config.timePerIntro;
            currentIndex += 1;
        }

        // Player

        // Player/Ski

        // Player/Jump

        // Player/Shooter

        // Enemies
    }
}
