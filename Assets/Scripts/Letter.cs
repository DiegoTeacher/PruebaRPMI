using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private TMP_Text textComponent;
    private Rigidbody2D rb;
    private char currentLetter;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        rb = GetComponent<Rigidbody2D>();

        currentLetter = (char)Random.Range(65, 91);
        textComponent.text = currentLetter.ToString();

        rb.gravityScale = Random.Range(0.1f, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(currentLetter.ToString().ToLower()))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // si me colisiono con la pala, me destruyo
        if(collision.GetComponent<PlayerMovement>())
        {
            Destroy(gameObject);
        }
    }
}
