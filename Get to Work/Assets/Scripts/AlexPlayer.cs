using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexPlayer : MonoBehaviour
{
    // Movement
    float xRunSpeed = 0.01f;
    float yRunSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Init input direction
        float dx = Input.GetAxis("Horizontal");
        bool run = !Input.GetKey("space");

        // Update velocity
        float vx = dx * xRunSpeed;
        float vy = 0.0f;
        if (run)
        {
            vy = -yRunSpeed;
        }

        // Update position
        transform.position = transform.position + new Vector3(vx,vy,0.0f);
    }
}
