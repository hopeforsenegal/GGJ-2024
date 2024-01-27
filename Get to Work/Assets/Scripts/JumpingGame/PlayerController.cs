using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JumpingGame
{
    public class PlayerController : MonoBehaviour
    {
        public float JumpForce;
        public float ChargeMultiplier;
        public float MaxCharge = 100;

        [Header("Sprites")]
        public Sprite Idle;
        public Sprite Jumping;
        public Sprite Win;

        private bool facingRight = true;

        private float jumpTimer;
        private bool holdingJump;

        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Slider slider;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            slider = GetComponentInChildren<Slider>();

            slider.gameObject.SetActive(false);
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

        public void StopMovement()
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            sr.sprite = Idle;
        }

        public void BounceHorizontal()
        {
            rb.velocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
        }

        public void Victory()
        {
            sr.sprite = Win;
        }

        private void HandleDirection()
        {
            if (!facingRight && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
            {
                facingRight = true;
                sr.flipX = false;
            }
            else if (facingRight && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
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
                slider.gameObject.SetActive(true);
                slider.maxValue = MaxCharge;
            
                Debug.Log("Jump Start");
            }

            if (holdingJump)
            {
                jumpTimer += Time.deltaTime;
                if (jumpTimer > MaxCharge)
                    jumpTimer = MaxCharge;
                slider.value = jumpTimer;
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
                slider.gameObject.SetActive(false);
                sr.sprite = Jumping;
            }
        }
    }
}
