using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.LoseLife();
        }
    }
}
