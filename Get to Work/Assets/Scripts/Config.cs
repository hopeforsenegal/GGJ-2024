using System;
using UnityEngine;

[Serializable]
public struct CutScene
{
    public Sprite screen;
    public float timePerText;
    public string[] dialouge;    
    public string nextLevel;
}

[CreateAssetMenu]
public class Config : ScriptableObject
{
    [Header("Game")]
    public string mainMenuScene;
    public string cutsceneManagerScene;

    [Header("Audio")]
    public AudioClip Menu;
    public AudioClip Lose;
    public AudioClip Win;


    [Header("UI")]
    public CutScene RunningGame;
    public CutScene JumpingGame;
    public CutScene ShootingGame;

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
}
