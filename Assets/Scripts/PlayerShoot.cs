using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float time;

    void Update() {
        time += Time.deltaTime;
        
        float nextFire = 1 / fireRate;
        
        if (Input.GetKeyDown("f") && time >= nextFire) {
            Shoot();
            time = 0;
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}
