using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovenet2 : MonoBehaviour
{
    public float maxSpeed = 8, acceleration, deceleration;

    private SpriteRenderer rend;
    private Rigidbody2D _rb2D;
    private Vector2 movementVector;
    public float currentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movementVector = new Vector2(x, y);

        if(x != 0 || y != 0) 
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            // estamos parados
            currentSpeed -= deceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        //if(currentSpeed > maxSpeed) 
        //{
        //    currentSpeed = maxSpeed; // LIMITE der
        //}
        //else if(currentSpeed < 0)
        //{
        //    currentSpeed = 0; // limite izq
        //}

        //transform.Translate(movementVector * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = movementVector * currentSpeed;
    }

    // getter
    public Vector2 GetMovementDirection() 
    {
        return movementVector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.GetComponent<Spider>())
        //{
        //    string currentSceneName = SceneManager.GetActiveScene().name;
        //    SceneManager.LoadScene(currentSceneName);
        //}
    }
}
