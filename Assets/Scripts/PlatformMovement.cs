using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { IDLE, WALKING, JUMPING }

public class PlatformMovement : MonoBehaviour
{
    public float speed = 3, jumpForce = 4, sphereRadius = 0.3f, jumpingVolume;
    public LayerMask groundMask;
    public AudioClip jumpingClip;

    private Rigidbody2D _rb;
    private Vector2 _dir;
    private bool isJumping = false;
    private PlayerState _currentState;
   
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _dir = new Vector2(Input.GetAxis("Horizontal"), 0);
        if(_dir.magnitude == 0)
        {
            _currentState = PlayerState.IDLE;
        }
        else 
        { 
            _currentState = PlayerState.WALKING;
        }
        Jump();
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_dir.x * speed, _rb.velocity.y);
        ApplyYForce();
    }

    void Jump() 
    {
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            _currentState = PlayerState.JUMPING;
            AudioManager.instance.PlayAudio(jumpingClip, "jumpingSounsObject", false, jumpingVolume);
        }
    }

    void ApplyYForce()
    {
        if(isJumping)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(Vector2.up * jumpForce * _rb.gravityScale, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(
            new Vector2(transform.position.x,
            transform.position.y), sphereRadius, groundMask);

        return collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x,
            transform.position.y), sphereRadius);
    }

    public PlayerState GetCurrentState()
    {
        return _currentState;
    }

    public Vector2 GetDirection()
    {
        return _dir;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //        canJump = true;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //        canJump = false;
    //}
}
