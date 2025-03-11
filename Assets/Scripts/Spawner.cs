using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    public GameObject objectToSpawn;

    private float currentTime;

    int Suma(int num1, int num2)
    {
        int suma = num2 + num1;
        return suma;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        //int res = Suma(4, 2);
        //Debug.Log(res);

        Debug.Log(NoSe(';', 29));
        Debug.Log(NoSe(';', 19));
        Debug.Log(NoSe(';', 889));
        Debug.Log(NoSe(';', 59));
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // currentTime = currentTime + Time.deltaTime
        
        if(currentTime >= timeToSpawn)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            currentTime = 0;
        }
    }

    bool NoSe(char letter, int value)
    {
        if (letter == (char)value) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
