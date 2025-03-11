using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed;
    public float returnTime;

    private float currentTime = 0;
    private Vector2 movementDirection = Vector2.right;
    private Rigidbody2D _rb;
    private Transform returnTransform;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= returnTime)
        {
            movementDirection = returnTransform.position - transform.position;
        }
    }

    // sobre todo, cada vez que hacemos algo con las fisicas
    private void FixedUpdate()
    {
        _rb.velocity = movementDirection * speed;
    }

    // setter
    public void SetMovementDirection(Vector2 newValue) 
    {
        movementDirection = newValue;
    }

    public void SetReturnTransform(Transform t)
    {
        returnTransform = t;
    }
}
