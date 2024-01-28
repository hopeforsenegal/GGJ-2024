using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexObstacle : MonoBehaviour
{
    // Timer
    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Despawn if out of view
        timer += 1;
        if (timer % 60 == 0 && Camera.main.transform.position.y+10 < transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
