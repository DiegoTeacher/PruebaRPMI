using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepasoSpawner : MonoBehaviour
{
    [Tooltip("Esto tiene que ser prefab")]
    public GameObject objectToSpawn;
    public float minTime, maxTime;
    public float width, height;

    private float currentTime, rndMaxTime;

    // Start is called before the first frame update
    void Start()
    {
        rndMaxTime = SelectRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= rndMaxTime)
        {
            currentTime = 0;
            rndMaxTime = SelectRandomTime();
            Instantiate(objectToSpawn, new Vector2(
                Random.Range(transform.position.x - width/2, transform.position.x + width/2),
                Random.Range(transform.position.y - height/2, transform.position.y + height/2)), 
                Quaternion.identity);
        }
    }

    private float SelectRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }
}
