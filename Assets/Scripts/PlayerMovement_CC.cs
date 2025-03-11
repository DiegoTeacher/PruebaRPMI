using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement_CC : MonoBehaviour
{
    [Header("Físicas")]
    public float speed;
    public float runningSpeed, acceleration, gravityScale, jumpForce;

    [Space(20)]
    [Header("Cámara")]
    public float mouseSens;

    public float yVelocity = 0, currentSpeed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);

        //for(int i = 0; i < 2073600; i++)
        //{
        //    Debug.Log(i);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        Jump(jumpPressed);
        Movement(x, z, shiftPressed);
        RotatePlayer(mouseX);       
    }

    void Jump(bool jumpPressed)
    {
        // salto
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity = 0;
            yVelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale);
        }
        // yVelocity += gravityScale * Time.deltaTime;
    }

    void Movement(float x, float z, bool shiftPressed)
    {
        if (shiftPressed)
        {
            currentSpeed += Time.deltaTime * acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, runningSpeed); // limitamos
        }
        else
        {
            currentSpeed += Time.deltaTime * acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, speed); // limitamos
        }

       
            //currentSpeed -= Time.deltaTime * acceleration;
            //currentSpeed = Mathf.Clamp(currentSpeed, 0, runningSpeed); // limitamos
        

        Vector3 movementVector = transform.forward * currentSpeed * z 
            + transform.right * currentSpeed * x;

        if (!characterController.isGrounded)
            yVelocity -= gravityScale;

        movementVector.y = yVelocity;

        movementVector *= Time.deltaTime; // mV = mV * dt

        characterController.Move(movementVector);
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    void RotatePlayer(float mouseX)
    {
        // ROTATION
        Vector3 rotation = new Vector3(0, mouseX, 0) * mouseSens * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
