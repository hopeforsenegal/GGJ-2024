using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizonalPatrol : MonoBehaviour
{
    public float speed;

    public float MinLeft;
    public float MaxRight;

    bool left;

    private void Update()
    {
        if (left)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < MinLeft)
                left = false;
        }
        else
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.position.x > MaxRight)
                left = true;
        }


    }
}
