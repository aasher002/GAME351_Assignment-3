using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrel : MonoBehaviour {
    public GameObject debris;
    public ParticleSystem explosion;
    public void Explode() {
        Destroy(gameObject);
        
        Instantiate(explosion, transform.position, Quaternion.identity);
        
        Quaternion debrisRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        Instantiate(debris, transform.position, debrisRotation);
    }
}
