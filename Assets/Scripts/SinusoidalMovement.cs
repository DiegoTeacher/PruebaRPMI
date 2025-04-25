using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MonoBehaviour
{
    public float xSpeed, ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(xSpeed, Mathf.Sin(Time.time) * ySpeed) * Time.deltaTime);
    }
}
