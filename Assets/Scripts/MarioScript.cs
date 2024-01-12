using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, jumpForce, rayDistance;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private Vector2 dir;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector2.zero;
        if(Input.GetKey(rightKey))
        {
            dir = Vector2.right;
        }
        else if(Input.GetKey(leftKey))
        {
            dir = new Vector2(-1, 0);
        }

        
        if(Input.GetKeyDown(jumpKey) && IsGrounded())
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if(dir != Vector2.zero)
        {
            rb.velocity = dir * speed;
        }

        if(isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce * rb.gravityScale));
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, Vector2.down, rayDistance);

        foreach(RaycastHit2D raycastHit in raycastHits)
        {
            if(raycastHit.collider.gameObject.CompareTag("Suelo"))
            {
                return true;
            }
        }

        return false; // hector has visto los TIKTOKS wake up is the first of the month una bala y estais muertos 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
