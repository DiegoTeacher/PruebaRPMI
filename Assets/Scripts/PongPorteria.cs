using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPorteria : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // devolver pelota pos inicial
        PongBall ball = collision.GetComponent<PongBall>();
        if (ball)
        {
            ball.ResetBall();
        } 
    }
}
