using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Config config;
    public Image imageToRotate;

    protected void Start()
    {
        LeanTween.rotate(imageToRotate.rectTransform, 360, 5).setLoopPingPong();

        LeanTween.delayedCall(9, () =>
        {
            GameAlwaysAlive.Instance.TransitionTo(GameState.MainMenu);
        });
    }
}
