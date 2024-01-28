using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JumpingGame
{
    public class PlayerController : MonoBehaviour
    {
        public Config config;

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

        public bool lose;

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
            if (lose)
            {
                return;
            }

            GameAlwaysAlive.Instance.runningTime += Time.deltaTime;

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
            LeanTween.moveLocal(Camera.main.gameObject, new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, -6), 1).setOnComplete(() =>
            {
                GameAlwaysAlive.Instance.TransitionTo(GameState.IntroShootingGame);
            });
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

            if (Input.GetKeyUp(KeyCode.Space)) {
                if (GameAlwaysAlive.Instance) { Debug.Log("1"); }
                if (GameAlwaysAlive.Instance.sfx) { Debug.Log("2"); }
                if (config) { Debug.Log("3"); }
                if (config) { Debug.Log("3"); }
                GameAlwaysAlive.Instance.sfx.clip = config.JumpSFX;
                GameAlwaysAlive.Instance.sfx.Play();

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
