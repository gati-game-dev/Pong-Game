using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private float speedIncrease = 0.25f;
    public TMP_Text speedText;
    private Rigidbody2D rb;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            gameManager.AddScore();
            speed += speedIncrease;
        }

        // Get the current direction of the ball
        Vector2 direction = rb.linearVelocity.normalized;

        // Prevent the ball from becoming almost completely vertical
        if (Mathf.Abs(direction.x) < 0.3f)
        {
            direction.x = direction.x >= 0 ? 0.3f : -0.3f;
        }

        // Prevent the ball from becoming almost completely horizontal
        if (Mathf.Abs(direction.y) < 0.3f)
        {
            direction.y = direction.y >= 0 ? 0.3f : -0.3f;
        }

        // Normalize again so we keep only the direction
        direction = direction.normalized;

        // Apply our desired speed to that direction
        rb.linearVelocity = direction * speed;

        speedText.text = "Speed: " + speed.ToString();
    }

    public void RestartBall()
    {
        transform.position = new Vector2(0,4);
        rb.linearVelocity = new Vector2(0,0);
        // SetRandomVelocity();
    }

    public void SetRandomVelocity()
    {
        float angle;

        if (Random.Range(0,2) == 0)
        {
            angle = Random.Range(30f, 150f);
        }
        else
        {
            angle = Random.Range(210f, 330f);
        }

        float radians = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector2 direction = new Vector2(x,y);

        Vector2 velocity = direction*speed;

        rb.linearVelocity = velocity;

    }
}
