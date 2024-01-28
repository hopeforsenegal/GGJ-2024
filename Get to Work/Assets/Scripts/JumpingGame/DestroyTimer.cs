using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpingGame
{


    public class DestroyTimer : MonoBehaviour
    {
        public float delay = 3;

        private void Start()
        {
            Invoke("DestroyThis", delay);
        }

        private void DestroyThis()
        {
            Destroy(gameObject);
        }
    }
}
