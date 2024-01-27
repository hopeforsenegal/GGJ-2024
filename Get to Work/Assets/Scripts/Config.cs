using UnityEngine;

[CreateAssetMenu]
public class Config : ScriptableObject
{
    [Header("Ski player")]
    public float skiPlayerSpeed;


    [Header("Jump player")]
    public float jumpPlayerSpeed;


    [Header("Shooter player")]
    public float shooterPlayerSpeed;
}
