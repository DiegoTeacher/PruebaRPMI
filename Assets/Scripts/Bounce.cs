using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMovement>() != null)
        {
            // rebotar
            // intenta acceder al componente rigidbody2d del padre
            Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
            if(rb != null) // si ha podido acceder
            {
                // le anyado fuerza en el eje Y
                rb.AddForce(new Vector2(0, force));
            }
        }
    }
}
