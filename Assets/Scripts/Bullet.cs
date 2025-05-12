using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody rb;

    void Start() {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter(Collider hitInfo) {
        Barrel barrel = hitInfo.GetComponent<Barrel>();
        Bandit bandit = hitInfo.GetComponent<Bandit>();
        Player player = hitInfo.GetComponent<Player>();

        if (hitInfo.GetComponent<Barrel>() != null) {
            barrel.Explode();
        }
        else if (hitInfo.GetComponent<Bandit>() != null) {
            bandit.Die();
        }
        else if (hitInfo.GetComponent<Player>() != null) {
            player.TakeDamage();
        }
        
        Destroy(gameObject);
    }
}
