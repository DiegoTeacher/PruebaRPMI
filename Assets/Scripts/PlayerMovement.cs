using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8;
    public Color leftColor, rightColor, upColor, downColor;
    public KeyCode rightKey, leftKey, upKey, downKey;

    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        //while(true)
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, 0);

        if (Input.GetKey(rightKey))
        {
            // si el usuario pulsa la D
            movement.x = speed;
            rend.color = rightColor;
        }
        else if (Input.GetKey(leftKey))
        {
            // si el usuario pulsa la A
            movement.x = -speed;
            rend.color = leftColor;

            //for (int i = 0; i < 10000; i++) {
            //    Debug.Log(i);
            //}
        }

        if (Input.GetKey(upKey))
        {
            // si el usuario pulsa la W
            movement.y = speed;
            rend.color = upColor;
        }
        else if (Input.GetKey(downKey))
        {
            // si el usuario pulsa la S
            movement.y = -speed;
            rend.color = downColor;
        }

        float x = Input.GetAxis("Horizontal");
        if(x != 0)
        {
            print("Haaa");
        }

        transform.Translate(movement * Time.deltaTime);

    }
}
