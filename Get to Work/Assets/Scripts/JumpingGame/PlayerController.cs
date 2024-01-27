using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpingGame
{
    public class PlayerController : MonoBehaviour
    {
        public float JumpForce;
        public float ChargeMultiplier;

        private bool facingRight = true;

        private float jumpTimer;
        private bool holdingJump;

        private Rigidbody2D rb;
        private SpriteRenderer sr;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            HandleDirection();
            HandleJump();

            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("Timer:" + jumpTimer);
                Vector2 force = new Vector2(1, 1) * JumpForce;
                rb.AddForceAtPosition(force, transform.position);
                Debug.Log("Jump Force:" + force);
            }
            
        }

        private void HandleDirection()
        {
            if (!facingRight && Input.GetKeyDown(KeyCode.RightArrow))
            {
                facingRight = true;
                sr.flipX = false;
            }
            else if (facingRight && Input.GetKeyDown(KeyCode.LeftArrow))
            {
                facingRight = false;
                sr.flipX = true;
            }
        }

        private void HandleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                holdingJump = true;
                Debug.Log("Jump Start");
            }

            if (holdingJump)
            {
                jumpTimer += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Vector2 direction;
                if (facingRight)
                    direction = new Vector2(0.4f, 1f);
                else
                    direction = new Vector2(-0.4f, 1f);

                jumpTimer *= ChargeMultiplier;
                if (jumpTimer < 1) jumpTimer = 1;
                Debug.Log("Jump End:" + jumpTimer);
                holdingJump = false;
                rb.AddForceAtPosition(direction * JumpForce * jumpTimer, transform.position);
                jumpTimer = 0;
            }
        }
    }
}
