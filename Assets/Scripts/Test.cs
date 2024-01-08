using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private char character = 'D';
    public int integer1 = 2, integer2 = 3;
    public GameObject prefab;
    Rigidbody2D rigidbody2D;
    public Color[] colores;
    private List<Color> listaColores;

    // Start is called before the first frame update
    void Start()
    {
        listaColores = new List<Color>();
        // 0
        listaColores.Add(Color.red);
        listaColores.Add(Color.red);
        listaColores.Add(Color.blue);
        listaColores.Add(Color.red);
        // 4
        listaColores.RemoveAt(2);
        // 3
        for(int i = 0; i < listaColores.Count; i++)
        {
            print(listaColores[i]);
        }

       //  colores = new Color[5];
        character = 'H';
        integer1 = integer1 * integer2;
        integer2 = integer2 + integer1;
        integer2++; // 10
        integer2 += integer1; // integer2 = integer2 + integer1;
        if (integer2 >= 10)
        {
            //PrintHola();
            //PrintHola();
            //PrintHola();
            //PrintHola();
            print(Add(10, 5));
            print(Add(1, 3));
            print(Add(-5, -20));

        }
        else if(integer2 == 8)
        {
            print("!!!!");
        }
        else
        {
            print("adios");
        }


        // integer1 = Random.Range(0, Array.Length); // [-3, 8)
    }

    public void PrintHola()
    {
        print("hola!");
        print("hola!");
        print("hola!");
        print("hola!");
    }

    public int Add(int num1, int num2)
    {
        return num1 + num2;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            // Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
