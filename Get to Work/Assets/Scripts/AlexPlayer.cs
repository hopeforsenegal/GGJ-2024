using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlexPlayer : MonoBehaviour
{
    public Config config;
    // States
    int state = 0;  // 0=Run, 1=Jump, 2=Wipeout Air, 3=Wipeout Ground

    // Objects
    public GameObject playerBody;
    public GameObject playerShadow;
    
    // Movement
    float runSpeed = 0.04f;
    Vector2 vel = new Vector2(0, 0);
    float dx = 0;

    // Air
    float yAirVel = 0;
    float gravStren = 0.0005f;
    float jumpStren = 0.06f;

    // Wipeout
    int wipeoutDuration = 180;
    int wipeoutTimer = 180;

    // Sprites
    public SpriteRenderer playerBodyRenderer;
    public RawImage bgImage;
    public Sprite[] runSprites;
    public Sprite[] jumpSprites;
    public Sprite[] wipeoutAirSprites;
    public Sprite[] wipeoutGroundSprites;
    float animCounter = 0.0f;
    float animSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameAlwaysAlive.DoUpdate(config);
        // Update animation
        animCounter += animSpeed;

        // Run state
        if (state == 0)
        {
            // Run animation
            playerBodyRenderer.sprite = runSprites[(int)animCounter % 2];

            // Init input direction
            dx = Input.GetAxis("Horizontal");

            // Jump
            if (Input.GetKeyDown("space"))
            {
                // Enter jump state
                state = 1;

                // Set jump velocity
                yAirVel = jumpStren;
            }

            // Update velocity
            vel.x = dx;
            vel.y = -1;
            vel.Normalize();
            vel *= runSpeed;
        }
        // Jump
        else if (state == 1)
        {
            // Jump animation
            playerBodyRenderer.sprite = jumpSprites[(int)animCounter % 2];

            // Init input direction
            dx = Input.GetAxis("Horizontal");

            // Update velocity
            vel.x = dx;
            vel.y = -1;
            vel.Normalize();
            vel *= runSpeed;

            // Jump velocity
            yAirVel -= gravStren;

            // Jump
            playerBody.transform.position += new Vector3(0f,yAirVel,0f);

            // Check landing
            if (playerBody.transform.position.y < transform.position.y)
            {
                state = 0;
            }
        }
        // Wipeout Air
        else if (state == 2)
        {
            // Wipeout Air animation
            playerBodyRenderer.sprite = wipeoutAirSprites[(int)animCounter % 2];

            // Update velocity
            vel.x = dx;
            vel.y = -1;
            vel.Normalize();
            vel *= runSpeed;

            // Jump velocity
            yAirVel -= gravStren;

            // Jump
            playerBody.transform.position += new Vector3(0f, yAirVel, 0f);

            // Check landing
            if (playerBody.transform.position.y < transform.position.y)
            {
                // Enter wipeout ground state
                state = 3;
                vel.x = 0;
                vel.y = 0;
            }
        }
        // Wipeout Ground
        else if (state == 3)
        {
            // Wipeout Air animation
            playerBodyRenderer.sprite = wipeoutGroundSprites[(int)animCounter % 1];

            // Decrement wipeout timer
            wipeoutTimer--;
            if (wipeoutTimer <= 0)
            {
                // Enter run state
                state = 0;
            }
        }

        // Update position
        transform.position = transform.position + new Vector3(vel.x, vel.y, 0.0f);

        // Check win condition
        if (transform.position.y < -50)
        {
            //Debug.Log("You made to work!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If hit something while running
        if (collision.gameObject.tag == "Obstacle")
        {
            // If in run state
            if (state == 0)
            {
                // Enter wipeout state
                state = 2;
                yAirVel = jumpStren;
                wipeoutTimer = wipeoutDuration;
            }
            // Else if already wiping out and close to ground
            else if (state == 2 &&  playerBody.transform.position.y - transform.position.y < 1f)
            {
                // Keep wiping out
                yAirVel = jumpStren;
            }
        }
    }
}
