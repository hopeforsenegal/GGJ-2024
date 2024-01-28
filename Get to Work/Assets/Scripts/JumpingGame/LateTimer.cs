using TMPro;
using UnityEngine;

namespace JumpingGame
{
    public class LateTimer : MonoBehaviour
    {
        public TMP_Text timerText;

        private void Update()
        {
            var t = System.TimeSpan.FromSeconds(GameAlwaysAlive.Instance.runningTime);

            // :Timer :Text
            timerText.text = $"You're Late! {($"{t.Minutes:D2}m {t.Seconds:D2}s")}";
        }
    }
}