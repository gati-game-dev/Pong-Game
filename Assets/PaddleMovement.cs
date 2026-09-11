using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 12f;
    private string horizontal = "Horizontal";
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movement = Input.GetAxis(horizontal);
        rb.linearVelocity = new Vector2(movement*speed, 0);
        
    }
}
