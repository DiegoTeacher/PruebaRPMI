using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject algoQueSpawnear;
    public float tiempoMinDisenyadorSpawnear, tiempoMaxDisenyadorSpawnear;

    private float timeToSpawn, tiempoActualParaSpawnear;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 0;
        tiempoActualParaSpawnear = Random.Range(tiempoMinDisenyadorSpawnear, tiempoMaxDisenyadorSpawnear);
    }

    // Update is called once per frame
    void Update()
    {
        timeToSpawn += Time.deltaTime;

        if(timeToSpawn >= tiempoActualParaSpawnear)
        {
            Instantiate(algoQueSpawnear, 
                new Vector2(Random.Range(-5, 5), transform.position.y), Quaternion.identity);
            timeToSpawn = 0;
            tiempoActualParaSpawnear = Random.Range(tiempoMinDisenyadorSpawnear, tiempoMaxDisenyadorSpawnear);
        }
    }
}
