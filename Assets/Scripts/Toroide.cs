using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toroide : MonoBehaviour
{
    private Camera cam;
    private SpriteRenderer _rend;
    private float spriteWidth, spriteHeight;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _rend = GetComponent<SpriteRenderer>();
        spriteWidth = _rend.bounds.size.x;
        spriteHeight = _rend.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        if(transform.position.y - spriteHeight / 2 > cam.transform.position.y + cam.orthographicSize)
        {
            // me he pasado por el limite superior de la camara
            transform.position = new Vector2(transform.position.x , cam.transform.position.y - cam.orthographicSize - spriteHeight/3);
        }
    }
}
