using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioScript : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpKey;
    public float speed, rayDistance;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private Vector2 dir;

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
    }

    private void FixedUpdate()
    {
        if(dir != Vector2.zero)
        {
            rb.velocity = dir * speed;
        }
    }

}
