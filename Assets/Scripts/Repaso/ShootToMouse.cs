using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMouse : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Camera _cam;
    public float cooldown;
    private float currentTime;
    public int numberOfBullets;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        // _cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButton(0))
        currentTime -= Time.deltaTime;

        if(Input.GetAxis("Fire1") > 0 && currentTime <= 0)
        {
            //Vector2 screenMouseCoords = Input.mousePosition;
            //Vector3 gameMouseCoords = _cam.ScreenToWorldPoint(screenMouseCoords);
            //GameObject bulletClone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //Vector2 bulletDirection = gameMouseCoords - transform.position;
            //bulletClone.GetComponent<Bullet>().SetMovementDirection(bulletDirection);
            CircleShoot();
            currentTime = cooldown;
        }
    }

    void CircleShoot() 
    {
        float angle = 0;
        float angleStep = 360f / numberOfBullets;

        for(int i = 0; i < numberOfBullets; i++)
        {
            float posX = transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad);
            float posY = transform.position.y + Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector3 bulletPosition = new Vector2(posX, posY);
            Vector3 bulletDir = bulletPosition - transform.position;
            GameObject bulletClone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletClone.GetComponent<Bullet>().SetMovementDirection(bulletDir);
            bulletClone.GetComponent<Bullet>().SetReturnTransform(transform);

            angle += angleStep;
        }
    }
}
