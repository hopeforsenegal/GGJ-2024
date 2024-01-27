using UnityEngine;
using UnityEngine.UI;

// We could populate these actions from the Config if we really wanted to
public static class Actions
{
    public static bool Left => Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
    public static bool Right => Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

    public static bool Shoot => Input.GetKeyDown(KeyCode.Space);

    // Take these out once we like the ending flow
    public static bool TestLose => Input.GetKey(KeyCode.Alpha1);
    public static bool TestWin => Input.GetKey(KeyCode.Alpha2);
}


public class Game : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public Config config;

    [Header("UI")]
    public Image winLoseScreen;

    protected void Start()
    {
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

        // Player

        // Player/Ski

        // Player/Jump

        // Player/Shooter

        // Enemies
    }
}
