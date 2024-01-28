using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JumpingGame
{
    public class LoseTimer : MonoBehaviour
    {
        public TMP_Text timerText;
        public GameObject LoseObject;

        public float maxTime = 60;

        private float timer = 0;

        private void Update()
        {
            timer += Time.deltaTime;

            timerText.text = "Don't Be Late! " + (maxTime - (int)timer);

            if (timer > maxTime)
            {
                LoseObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().lose = true;
            }
        }


        public void TryAgain()
        {
            SceneManager.LoadScene("Nathan", LoadSceneMode.Single);
        }


    }
}
