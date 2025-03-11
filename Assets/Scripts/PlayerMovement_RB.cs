using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_RB : MonoBehaviour
{
    public float walkingSpeed, runningSpeed, acceleration, jumpForce, mouseSens, sphereRadius/*, gravityScale*/;
    public string groundName;

    private Rigidbody rb;

    private float x, z, mouseX; // input
    private bool shiftPressed;
    private bool jumpPressed;

    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // gravityScale = -Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        shiftPressed = Input.GetKey(KeyCode.LeftShift);
        mouseX = Input.GetAxis("Mouse X");
        
        // INTERPOLACION DE LA VELOCIDAD
        if(shiftPressed && (x != 0 || z != 0))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, acceleration * Time.deltaTime);
        }
        else if(x != 0 || z != 0)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, walkingSpeed, acceleration * Time.deltaTime);
        }
        else 
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, acceleration * Time.deltaTime);
        }
        

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpPressed = true;
        }
        // /jump

        RotatePlayer();
    }

    void RotatePlayer() 
    {
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime;
        transform.Rotate(rotation);
    }

    private void FixedUpdate()
    {
        ApplySpeed();
        ApplyJumpForce();
    }

    void ApplySpeed()
    {
        rb.velocity = (transform.forward * currentSpeed * z) + (transform.right * currentSpeed * x) +
           new Vector3(0, rb.velocity.y, 0);
        /*+ (transform.up * gravityScale)*/
        // rb.AddForce(transform.up * gravityScale);
    }

    void ApplyJumpForce()
    {
        if (jumpPressed)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce);
            jumpPressed = false;
        }
    }

    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(new Vector3(transform.position.x,
            transform.position.y, transform.position.z), sphereRadius);

        for (int i = 0; i < colliders.Length; i++) // recorrenos elemento a elemento
        {
            // y comprobamos si ese elemento es suelo
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer(groundName))
            {
                return true;
            }
        }

        return false;
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x,
            transform.position.y, transform.position.z), sphereRadius);
    }
}
