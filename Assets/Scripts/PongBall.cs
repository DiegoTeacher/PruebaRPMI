using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PongBall : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 initialPosition;
    private float originalSpeed;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0;

        originalSpeed = speed;
        initialPosition = transform.position;
        ResetBall();
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    public void ChangeYDirection()
    {
        direction.y = -direction.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChangeYDirection();
        if(collision.gameObject.GetComponent<RepasoPalaMovement>())
        {
            direction.x = -direction.x;
            direction.y = Random.Range(-1, 2);
            speed *= 1.2f; // speed = speed * 2;
        }
    }
    
    public void ResetBall()
    {
        transform.position = initialPosition;
        speed = originalSpeed;

        direction.y = Random.Range(-1, 2); // [-1, 2)

        do
        {
            direction.x = Random.Range(-1, 2);
        } while (direction.x == 0);
    }
}
