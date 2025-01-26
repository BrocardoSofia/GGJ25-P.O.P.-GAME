using System;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireForce;
    
    public int bulletCount;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletCount > 0)
        {
            GameObject newBullet;
            newBullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * fireForce);
            Destroy(newBullet, 2f);
        }
    }
}