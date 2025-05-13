using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bandit : MonoBehaviour
{
    public Animator animator;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    [Space]
    public GameObject target;
    public float min_angle;
    public float max_angle;

    [Header("Sound Effects")]
    public AudioClip[] painClips;
    public AudioClip deathClip;
    public AudioClip[] tauntClips; 

    private AudioSource audioSource;
    private float fireRate;
    private float time;

    private bool isDead;

    private float tauntTimer; 
    private float tauntIntervalMin = 10f; // Min time between taunts (in seconds)
    private float tauntIntervalMax = 30f; // Max time between taunts (in seconds)

    private void Start() {
        fireRate = Random.Range(30f, 61f);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // Make it 3D positional
        audioSource.spatialBlend = 1f;
        audioSource.minDistance = 5f;
        audioSource.maxDistance = 25f;
        audioSource.rolloffMode = AudioRolloffMode.Logarithmic;

        tauntTimer = Random.Range(tauntIntervalMin, tauntIntervalMax);
    }

    void Update() {
        if (!isDead) {
            FaceTarget();
            
            time += Time.deltaTime;
        
            if (time >= fireRate) {
                Shoot();
                time = 0;
            }

            tauntTimer -= Time.deltaTime;
            if (tauntTimer <= 0)
            {
                Taunt();
                tauntTimer = Random.Range(tauntIntervalMin, tauntIntervalMax); 
            }
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    void Shoot() {
        var angleX = Random.Range(min_angle, max_angle);
        var angleY = Random.Range(min_angle, max_angle);
        var angleZ = Random.Range(min_angle, max_angle);
        
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.Rotate(angleX, angleY, angleZ);
        
        fireRate = Random.Range(30f, 61f);
    }

    void PlayPainSound() {
        if (painClips.Length > 0) {
            AudioClip clip = painClips[Random.Range(0, painClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

    void Taunt()
    {
        if (tauntClips.Length > 0)
        {
            AudioClip tauntClip = tauntClips[Random.Range(0, tauntClips.Length)];
            audioSource.PlayOneShot(tauntClip);
        }
    }
    
    public void Die() {
        isDead = true;
        
        int randDeath = Random.Range(1, 3);
        
        animator.SetInteger("deathID", randDeath);
        animator.SetBool("isDead", true);

        PlayPainSound();
    }
}
