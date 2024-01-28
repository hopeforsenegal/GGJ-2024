using System;
using UnityEngine;

[Serializable]
public struct CutScene
{
    public Sprite screen;
    public float timePerText;
    public string[] dialouge;
    public string levelToLoad;
}

[CreateAssetMenu]
public class Config : ScriptableObject
{
    [Header("Game")]
    public string mainMenuScene;
    public string cutsceneManagerScene;
    public string winScene;

    [Header("Audio")]
    public AudioClip MenuMusic;
    public AudioClip RunMusic;
    public AudioClip JumpMusic;
    public AudioClip ShootMusic;
    [Header("Audio/Jump")]
    public AudioClip JumpSFX;


    [Header("UI")]
    public CutScene RunningGame;
    public CutScene JumpingGame;
    public CutScene ShootingGame;
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
