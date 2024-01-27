using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace JumpingGame
{
    public class Door : MonoBehaviour
    {

        public TMP_Text text;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                text.gameObject.SetActive(true);
                text.text = "You Made It!";
                collision.GetComponent<PlayerController>().Victory();
            }

        }
    }
}
