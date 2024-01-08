using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lettermovement : MonoBehaviour
{
    public float speed;
    public char letter;

    private TextMeshPro textComponet;

    // Start is called before the first frame update
    void Start()
    {
        int resultado = Add(10, 20);
        Debug.Log(resultado);

        resultado = Add(3, 2);
        Debug.Log(resultado);

        resultado = Add(10, 20);
        Debug.Log(resultado);

        // letter debe ser aleatorio
        letter = (char)Random.Range(65, 91);
        textComponet = GetComponent<TextMeshPro>();
        textComponet.text = letter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2( 0.0f,-speed) * Time.deltaTime);

        if(Input.GetKeyDown(char.ToLower(letter).ToString()))
        {
            Destroy(gameObject);
        }
    }

    void SayHello()
    {
        Debug.Log("Hello!!");
    }

    void SayMyName(string name)
    {
        Debug.Log("Mi nombre es: " + name);
    }

    int Add(int n1, int n2)
    {
        int res = n1 + n2;
        return res;
    }
}
