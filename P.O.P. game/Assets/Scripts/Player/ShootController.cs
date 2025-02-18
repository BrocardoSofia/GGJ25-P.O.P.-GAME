using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class ShootController : MonoBehaviour
{
    [SerializeField]
    public AudioSource SFXSource;

    public AudioClip shootSound;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireForce;
    

    public int bulletCount;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bulletCount > 0)
        {
            SFXSource.PlayOneShot(shootSound);
            GameObject newBullet;
            newBullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * fireForce);
            Destroy(newBullet, 2f);
        }
    }
}