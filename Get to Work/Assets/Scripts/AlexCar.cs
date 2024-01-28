using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCar : MonoBehaviour
{
    // Timer
    int timer = 0;

    // Movement
    float xVel;

    // Start is called before the first frame update
    void Start()
    {
        float displacement = Camera.main.transform.position.x - transform.position.x;
        xVel = displacement * 0.4f;
        if (displacement < 0)
        {
            xVel *= -1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        transform.position = transform.position + new Vector3(xVel *Time.deltaTime,0f,0f);

        // Despawn if out of view
        timer += 1;
        if (timer % 60 == 0 && Camera.main.transform.position.y + 10 < transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
