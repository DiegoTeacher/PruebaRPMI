using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb.velocity = new Vector2(xSpeed, 0);
        }
    }
}

int[] theArray = new int[5, -13, 8, 0];

for(int i = 0; i < theArray.Length; i++) {
    Debug.Log(theArray[i]);
}
