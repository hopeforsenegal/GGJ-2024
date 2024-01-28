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
    private CameraManager manager;

    void Start()
    {
        manager = FindObjectOfType<CameraManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
        manager.OnBulletEnemyCollision(enemy, this);

        }
        else
        {
            Debug.Log($"We it not a enemy? {collision.gameObject.name}");
        }
    }

}
