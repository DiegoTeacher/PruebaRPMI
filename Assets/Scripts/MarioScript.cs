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
    public AudioClip jumpClip;
    public int maxJumps = 2;

    private Character character;
    private Rigidbody2D rb;
    private SpriteRenderer _rend;
    private Animator _animator;
    private Vector2 dir;
    private bool _intentionToJump;
    private int currentJumps = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        int rnd = Random.Range(0, 2);
        if (rnd == 0)
            character = new Cowboy("Alejandro", 100);
        else
            character = new Wizard("Alejandro", 100, true);

        jumpForce = character.GetJumpForce();
        _rend.sprite = character.GetSprite();
        _rend.color = character.color;
    }

    // Update is called once per frame
    void Update()
    {
        character.Update(rb);
        print(GameManager.instance.GetTime());

        dir = Vector2.zero;
        if (Input.GetAxis("Horizontal") > 0)
        {
            _rend.flipX = false;
            dir = Vector2.right;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            _intentionToJump = true;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            character.Skill(rb);
        }

        #region ANIMACIONES
        // ANIMACIONES (PROXIMA DIA ORGANIZARLO EN OTRO SCRIPT)
        if (dir != Vector2.zero)
        {
            // estamos andando
            _animator.SetBool("isWalking", true);
        }
        else
        {
            // estamos parados
            _animator.SetBool("isWalking", false);
        }
        #endregion
    }

    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
        // if (dir != Vector2.zero)
        {
            float currentYVel = rb.velocity.y;
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel;

            rb.velocity = nVel;
        }
        if (_intentionToJump && (grnd || currentJumps < maxJumps - 1))
        {
            _animator.Play("jumpAnimation");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
            currentJumps++; // le suma 1 a la variable = currentJumps = currentJumps + 1;
            AudioManager.instance.PlayAudio(jumpClip, "jumpSound");
        }
        _intentionToJump = false; 

        _animator.SetBool("isGrounded", grnd);
    }

    private bool IsGrounded()
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        if (collision)
        {
            currentJumps = 0;
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
