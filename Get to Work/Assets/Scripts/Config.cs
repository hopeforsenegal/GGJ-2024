using UnityEngine;

public struct CutScene
{
    public Sprite screen;
    public float timePerText;
    public string[] dialouge;
}

[CreateAssetMenu]
public class Config : ScriptableObject
{
    [Header("Audio")]
    public AudioClip Menu;
    public AudioClip Lose;
    public AudioClip Win;


    [Header("UI")]
    public CutScene IntroRunningGame;

    public Sprite LoseScreen;
    public Sprite WinScreen;


    [Header("Player")]
    public bool temp;

    [Header("Player/Ski")]
    public float skiPlayerSpeed;

    [Header("Player/Jump")]
    public float jumpPlayerSpeed;

    [Header("Player/Shooter")]
    public float shooterPlayerSpeed;


    [Header("Levels")]
    public string firstLevel;
}
