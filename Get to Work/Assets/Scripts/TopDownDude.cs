using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownDude : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingLeft;
    public Config config;
    float speedX, speedY;
    Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    public bool test;
    public bool spawnFacingLeft;
    private Vector2 facingLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log("hello");
        /*facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if(spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }*/
        test = true;
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * config.shooterPlayerSpeed;
        speedY = Input.GetAxisRaw("Vertical") * config.shooterPlayerSpeed;
        rb.velocity = new Vector2(speedX, speedY);

        spriteRenderer = GetComponent<SpriteRenderer>();

        /*if (Input.GetKeyDown(KeyCode.LeftArrow)|| (Input.GetKeyDown(KeyCode.D))
            {
            test = true;
            }
        if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.A))
            {
            test = false;
            }
        if (test = false)
        {
            
        }*/
        
    }
    private void FixedUpdate()
    {
        //spriteRenderer.flipX = rb.velocity.x < 0f;

    }


}
