using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlatformMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position)
             < 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,
                transform.position.y, transform.position.z)
                , speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,
               transform.position.y, transform.position.z)
               , player.GetComponent<PlatformMovement>().speed * Time.deltaTime);
        }
            //transform.position = new Vector3(player.transform.position.x,
            //transform.position.y, transform.position.z);
    }
}
