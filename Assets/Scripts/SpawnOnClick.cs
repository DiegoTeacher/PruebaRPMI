using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    public GameObject objToSpawn;
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Vector2 mouseCoords = Input.mousePosition;
            Vector2 gameCoords = _cam.ScreenToWorldPoint(mouseCoords);

            Instantiate(objToSpawn, gameCoords, Quaternion.identity);
        }
    }
}
