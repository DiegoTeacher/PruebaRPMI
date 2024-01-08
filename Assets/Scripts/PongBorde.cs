using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBorde : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PongBall ballComponent = collision.gameObject.GetComponent<PongBall>();
        if (ballComponent != null)
        {
            // direction.y = -direction.y
            ballComponent.ChangeYDirection();
        }
    }
}
