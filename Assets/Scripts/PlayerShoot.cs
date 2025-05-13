using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioClip gunshotClip;
    private AudioSource audioSource;
    public MusicManager musicManager;

    public float fireRate = 1f;
    private float time;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        time += Time.deltaTime;
        
        float nextFire = 1 / fireRate;
        
        if (Input.GetKeyDown("f") && time >= nextFire) {
            Shoot();
            PlayGunshotSound();
            time = 0;

            if (musicManager != null) {
                Debug.Log("starting fight music");
                musicManager.PlayFight(); 
            }
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }

    void PlayGunshotSound() {
        if (audioSource != null) {
            audioSource.PlayOneShot(gunshotClip);
        }
    }
}
