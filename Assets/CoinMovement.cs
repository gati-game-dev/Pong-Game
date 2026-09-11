using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float speed = 3f;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            gameManager.AddCoinScore();
            Destroy(gameObject);
        }
    }
}
