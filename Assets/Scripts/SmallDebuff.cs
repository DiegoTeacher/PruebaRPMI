using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDebuff : MonoBehaviour
{
    public float maxTime = 4;
    private float currentTime;
    private Vector3 initialScale;
    
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;

        transform.localScale =
            new Vector3(transform.localScale.x,
            transform.localScale.y / 2,
            transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > maxTime)
        {
            currentTime = 0;
            transform.localScale = initialScale;
            Destroy(this); // quita el componente del gameobject
        }
    }
}
