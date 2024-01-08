using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepasoPalaMovement : MonoBehaviour
{
    public float speed;
    public KeyCode upKey, downKey;

    private Rigidbody2D _rb;
    private Vector2 _direction;

    public int[] array;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;

        for(int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                print(array[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _direction = Vector2.zero;
        if(Input.GetKey(upKey))
        {
            _direction = new Vector2(0, 1);
        }
        else if (Input.GetKey(downKey))
        {
            _direction = new Vector2(0, -1);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _direction * speed;
    }
}
