using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexNPC : MonoBehaviour
{
    public AlexRunner runner;
    public GameObject parent;

    // Thinking
    int thinkCounter = 0;
    int thinkFreq = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If time to think
        thinkCounter++;
        if (thinkCounter % thinkFreq == 0)
        {
            // Despawn if out of view
            if (Camera.main.transform.position.y + 10 < transform.position.y)
            {
                Destroy(parent);
            }
            else
            {
                // Update inputs
                runner.dx = Random.Range(-1, 2);
                if (Random.Range(0, 100) < 10)
                {
                    runner.jumpPressed = true;
                }
            }
        }
    }
}
