using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    public float playerHealth, health, maxHealth = 3f;
    public bool isRoomActive = false;

    public float moveSpeed = 5f;
    Rigidbody2D rb;
    Transform target;

    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerHealth = 3f;
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Damage Amount: {damageAmount}");
        health -= damageAmount;
        Debug.Log($"Health is now: {health}");

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
 
    void Update()
    {
        if (isRoomActive = true)
        {
            if (target)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                moveDirection = direction;
            }

        }
        else
        {
            Debug.Log("No Target?");
        }

    }

     // if(Enemy)
   

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ey1");
        var player = collision.gameObject.GetComponent<TopDownDude>();
        if (player != null)
        {
            playerHealth -= 1;
            Debug.Log("Enemy Touched You");
            Debug.Log($"PLayer Health is now: {playerHealth}");
            if (playerHealth <= 0)
            {
                Destroy(player.gameObject);
            }
        }

    }
}
