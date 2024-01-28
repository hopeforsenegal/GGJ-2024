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
        manager.OnBulletCollision(collision, this);
    }

}
