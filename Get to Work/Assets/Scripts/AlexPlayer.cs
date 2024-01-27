using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexPlayer : MonoBehaviour
{
    // Movement
    float runSpeed = 0.04f;
    Vector2 vel = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Init input direction
        float dx = Input.GetAxis("Horizontal");

        // Update velocity
        vel.x = dx;
        vel.y = -1;
        vel.Normalize();
        vel *= runSpeed;

        // Update position
        transform.position = transform.position + new Vector3(vel.x,vel.y,0.0f);

        // Check win condition
        if (transform.position.y < -20)
        {
            //Debug.Log("You made to work!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Obstacle hit!");
        }
    }
}
