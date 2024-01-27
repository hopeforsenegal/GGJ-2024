using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeTillDeath = 3;


    void Awake()
    {
        Destroy(gameObject, timeTillDeath);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {

            Debug.Log($"Damage Amount: {1}");
            enemy.health -= 1;
            Debug.Log($"Health is now: {enemy.health}");

            if (enemy.health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        Destroy(gameObject);
    }
}
