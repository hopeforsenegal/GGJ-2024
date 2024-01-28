using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnUp;
    public Transform bulletSpawnDown;
    public Transform bulletSpawnLeft;
    public Transform bulletSpawnRight;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnRight.position, bulletSpawnRight.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnRight.right * bulletSpeed;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnUp.position, bulletSpawnUp.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnUp.up * bulletSpeed;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnDown.position, bulletSpawnDown.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnDown.up * bulletSpeed;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnLeft.position, bulletSpawnLeft.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnLeft.right * bulletSpeed;
        }
    }
}
