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

    private float fireRate;
    private float time;

    private bool isDead;

    private void Start() {
        fireRate = Random.Range(30f, 61f);
    }

    void Update() {
        if (!isDead) {
            FaceTarget();
            
            time += Time.deltaTime;
        
            if (time >= fireRate) {
                Shoot();
                time = 0;
            }
        }
    }

    void FaceTarget() {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        fireRate = Random.Range(30f, 61f);
    }
    
    public void Die() {
        isDead = true;
        
        int randDeath = Random.Range(1, 3);
        
        animator.SetInteger("deathID", randDeath);
        animator.SetBool("isDead", true);
    }
}
