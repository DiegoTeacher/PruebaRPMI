using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 5;
    public KeyCode leftKey = KeyCode.A, rightKey = KeyCode.D, upKey, downKey;
    private Camera _camera;
    private SpriteRenderer _rend;
    private Rigidbody2D rb;
    private Vector2 _dir;

    public Color[] colors;
    private int index = 0;

    private List<string> genteQueVaAFaltar;

    private void Start()
    {
        _camera = Camera.main;
        _rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        for (int i = 0; i < colors.Length; i++)
        {
            print(colors[i]);
        }

        genteQueVaAFaltar = new List<string>();
        genteQueVaAFaltar.Add("Yanes");
        genteQueVaAFaltar.Add("Alonso");
        genteQueVaAFaltar.Add("María");
        genteQueVaAFaltar.Add("Carlos");

        foreach (string persona in genteQueVaAFaltar)
        {
            Debug.Log(persona);
        }

        genteQueVaAFaltar.RemoveAt(1);

        foreach (string persona in genteQueVaAFaltar)
        {
            Debug.Log(persona);
        }
    }

    private void CheckBounds()
    {
        if (transform.position.y - _rend.bounds.size.y / 2 >= _camera.transform.position.y + _camera.orthographicSize)
        {
            transform.position =
                new Vector2(transform.position.x,
                _camera.transform.position.y - _camera.orthographicSize - _rend.bounds.size.y / 3);
        }
        else if (transform.position.y + _rend.bounds.size.y / 2 <= _camera.transform.position.y - _camera.orthographicSize)
        {
            transform.position =
                new Vector2(transform.position.x,
                _camera.transform.position.y + _camera.orthographicSize + _rend.bounds.size.y / 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
        Movement();
        Shoot();
    }

    void Shoot()
    {
        // si el usuario pulsa el boton izq del raton
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bullet1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet1.GetComponent<Bullet>().direction = Vector2.right;
            GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet2.GetComponent<Bullet>().direction = -Vector2.right;
            GameObject bullet3 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet3.GetComponent<Bullet>().direction = Vector2.up;
            GameObject bullet4 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet4.GetComponent<Bullet>().direction = -Vector2.up;
        }
    }

    void Movement()
    {
        _dir = new Vector2(0, 0);
        // mueve pj ...
        if (Input.GetKey(leftKey))
        {
            _dir = new Vector2(-1, _dir.y);
        }
        else if (Input.GetKey(rightKey))
        {
            _dir = new Vector2(1, _dir.y);
        }
        if (Input.GetKey(downKey))
        {
            _dir = new Vector2(_dir.x, -1);
        }
        else if (Input.GetKey(upKey))
        {
            _dir = new Vector2(_dir.x, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, speed) * _dir;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<lettermovement>() != null)
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
}
