using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PalaMovement : MonoBehaviour
{
    public float speed;
    public KeyCode upKey, downKey;

    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(0, 0);
        if(Input.GetKey(upKey))
        {
            direction = new Vector2(0, 1);
        }
        else if(Input.GetKey(downKey))
        {
            direction = new Vector2(0, -1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
