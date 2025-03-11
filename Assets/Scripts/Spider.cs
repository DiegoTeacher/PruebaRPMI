using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public GameObject prefab;
    public float speed;
    public GameObject target;
    public int maxDivisions = 2;
    private int currentDivision = 0;
    // public PlayerMovement target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovenet2>().gameObject;
        //int num1 = 2, num2 = -3;
        //int res2;

        //int res1 = Suma(num1, num2);
        //res2 = Suma(5, 3);
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    void FollowTarget() 
    {
        // 1. declaro variable newPosition y asigno al resultado del metodo
        // donde estamos
        Vector2 newPosition = Vector2.MoveTowards(transform.position,
            // adonde vamos                // a qué velocidsad
            target.transform.position, speed * Time.deltaTime);

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(collision.gameObject);

            if (currentDivision < maxDivisions)
            {
                int rndPieces = Random.Range(2, 5);
                for (int i = 0; i < rndPieces; i++)
                {
                    GameObject nObject = Instantiate(prefab, transform.position, Quaternion.identity);
                    nObject.transform.localScale /= 2;
                    nObject.GetComponent<Spider>().currentDivision = currentDivision + 1;
                }
            }

            Destroy(gameObject);
        }
    }

    //int Suma(int a, int b)
    //{
    //    return a + b;
    //}
}
