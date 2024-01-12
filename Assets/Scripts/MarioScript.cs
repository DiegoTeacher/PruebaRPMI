using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, rayDistance, jumpForce;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private Vector2 dir;
    private bool _intentionToJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector2.zero;
        if (Input.GetKey(rightKey))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(leftKey))
        {
            dir = new Vector2(-1, 0);
        }

        _intentionToJump = false;
        if(Input.GetKey(jumpKey))
        {
            _intentionToJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (dir != Vector2.zero)
        {
            float currentYVel = rb.velocity.y;
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel;

            rb.velocity = nVel;
        }
        
        if(_intentionToJump && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
            _intentionToJump = false;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (collision)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
