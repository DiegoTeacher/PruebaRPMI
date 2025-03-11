using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAuto : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float timeBetweenBullet;

    private float currentTime = 0;
    private bool toggleShootType;

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (Input.GetAxis("Fire1") != 0 && currentTime <= 0)
        {
            if(toggleShootType)
                ShootToMouse();
            else
                ShootFourDir();

            currentTime = timeBetweenBullet;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            toggleShootType = !toggleShootType;
        }
    }

    void ShootFourDir()
    {
        ShootToDir(Vector2.up);
        ShootToDir(Vector2.right);
        ShootToDir(Vector2.left);
        ShootToDir(Vector2.down);
    }

    void ShootToDir(Vector2 dir)
    {
        GameObject loQueEstaInstanciando =
               Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        loQueEstaInstanciando.GetComponent<Bullet>().SetMovementDirection(dir);
    }

    void ShootToMouse()
    {
        GameObject loQueEstaInstanciando =
               Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 mouseCoords = Input.mousePosition;
        Vector3 gameCoords = Camera.main.ScreenToWorldPoint(mouseCoords);
        Vector2 dir = gameCoords - transform.position;

        loQueEstaInstanciando.GetComponent<Bullet>().SetMovementDirection(dir);
    }
}
