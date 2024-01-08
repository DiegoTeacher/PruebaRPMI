using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<RepasoPalaMovement>())
        {
            // ESTO ES NUEVO, NO ENTRARA EN EL PRACTICO
            collision.gameObject.AddComponent<SmallDebuff>();
            Destroy(gameObject);
        }
    }
}
