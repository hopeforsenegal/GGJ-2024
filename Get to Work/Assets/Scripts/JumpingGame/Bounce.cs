using System.Collections;
using System.Collections.Generic;
using JumpingGame;
using UnityEngine;

namespace JumpingGame
{
    public class Bounce : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Door"))
            {
                return;
            }
            GetComponentInParent<PlayerController>().BounceHorizontal();
        }
    }
}
