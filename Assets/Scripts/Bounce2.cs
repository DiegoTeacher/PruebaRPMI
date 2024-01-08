using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce2 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));
        }
    }
}
