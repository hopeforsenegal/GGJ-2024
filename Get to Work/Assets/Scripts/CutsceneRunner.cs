using System;
using UnityEngine;
using UnityEngine.UI;

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
        if (GameAlwaysAlive.Instance.currentState == GameState.IntroRunningGame || GameAlwaysAlive.Instance.currentState == GameState.IntroJumpingGame || GameAlwaysAlive.Instance.currentState == GameState.IntroShootingGame) {
            m_Game = GameAlwaysAlive.Instance.currentState switch
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
        if (GameAlwaysAlive.Instance.currentState == GameState.Win) {
            winLoseScreen.enabled = true;
            winLoseScreen.sprite = config.WinScreen;
        }

        if (Input.anyKeyDown || (cutsceneTimer -= Time.deltaTime) <= 0) {
            if (cutsceneIndex < m_Game.dialouge.Length - 1) {
                cutsceneText.text = m_Game.dialouge[cutsceneIndex + 1];
            }

            if (cutsceneIndex == m_Game.dialouge.Length - 1) {
                var newState = GameAlwaysAlive.Instance.currentState switch
                {
                    GameState.IntroRunningGame => GameState.RunningGame,
                    GameState.IntroJumpingGame => GameState.JumpingGame,
                    GameState.IntroShootingGame => GameState.ShootingGame,
                    _ => throw new ArgumentOutOfRangeException($"{GameAlwaysAlive.Instance.currentState}"),
                };
                GameAlwaysAlive.Instance.TransitionTo(newState);
            }
            cutsceneTimer = m_Game.timePerText;
            cutsceneIndex += 1;
        }
    }
}
