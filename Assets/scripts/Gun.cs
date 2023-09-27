using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform player;
    public float bulletSpeed = 20f;
    public void StartShooting(float interval)
    {
        CancelInvoke();
        InvokeRepeating("Shoot", 0f, interval);

    }

    void Start()
    {
        // Start shooting at regular intervals
        StartShooting(2);
        
    }

    private void Update()
    {
        transform.LookAt(player);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = bulletSpawnPoint.forward * bulletSpeed;
            
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component.");
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(bulletPrefab, 5);
    }


}
