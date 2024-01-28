using UnityEngine;
using UnityEngine.SceneManagement;
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

public class CutsceneRunner : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public Config config;

    [Header("UI")]
    public CanvasGroup dialougeCanvasGroup;
    public Image cutsceneImage;
    public Text cutsceneText;
    public Image winLoseScreen;

    private int cutsceneIndex;
    private float cutsceneTimer;
    private CutScene m_Game;

    protected void Start()
    {
        if (GameAlwaysAlive.currentState == GameState.IntroRunningGame || GameAlwaysAlive.currentState == GameState.IntroJumpingGame || GameAlwaysAlive.currentState == GameState.IntroShootingGame) {
            m_Game = GameAlwaysAlive.currentState switch
            {
                GameState.IntroRunningGame => config.RunningGame,
                GameState.IntroJumpingGame => config.JumpingGame,
                GameState.IntroShootingGame => config.ShootingGame,
                _ => throw new System.NotImplementedException(),
            };
            cutsceneImage.sprite = m_Game.screen;
            cutsceneText.text = m_Game.dialouge[cutsceneIndex];
            cutsceneTimer = m_Game.timePerText;
        }
        dialougeCanvasGroup.alpha = 1;
        dialougeCanvasGroup.blocksRaycasts = true;
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
            if (cutsceneIndex < m_Game.dialouge.Length - 1) {
                cutsceneText.text = m_Game.dialouge[cutsceneIndex + 1];
            }

            if (cutsceneIndex == m_Game.dialouge.Length - 1) {
                SceneManager.LoadScene(m_Game.nextLevel);
            }
            cutsceneTimer = m_Game.timePerText;
            cutsceneIndex += 1;
        }

        // Player

        // Player/Ski

        // Player/Jump

        // Player/Shooter

        // Enemies
    }
}
