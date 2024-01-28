using UnityEngine;

public class TopDownDude : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingLeft;
    public Config config;
    float speedX, speedY;
    Rigidbody2D rb;

    public bool test;
    public bool spawnFacingLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        test = true;
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * config.shooterPlayerSpeed;
        speedY = Input.GetAxisRaw("Vertical") * config.shooterPlayerSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }
}
