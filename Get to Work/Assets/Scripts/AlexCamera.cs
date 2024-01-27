using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCamera : MonoBehaviour
{
    // Spawning
    public GameObject bush;

    // Timer
    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Regularly spawn bush
        timer += 1;
        if (timer % 60 == 0)
        {
            float x = transform.position.x + Random.Range(-10f,10f);
            float y = transform.position.y - 10f;
            Instantiate(bush, new Vector3(x,y,0),Quaternion.identity);
        }
    }

    // Spawn
}
