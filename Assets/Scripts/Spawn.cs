using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject letterPrefab;
    private float currentTime = 0;
    private float maxTime;
    private BoxCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = Random.Range(0.3f, 5f);
        collider2D = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTime)
        {
            Instantiate(letterPrefab, transform.position, Quaternion.identity);
            currentTime = 0;
            maxTime = Random.Range(0.3f, 5f);
        }
    }
}
