using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExplosionTrigger : MonoBehaviour
{
    public AudioSource explosionAudioSource; 
    public float explosionDelay = 2f; 

    void Start()
    {
        StartCoroutine(PlayExplosionAfterDelay());
    }

    IEnumerator PlayExplosionAfterDelay()
    {
        yield return new WaitForSeconds(explosionDelay);
        
        // Play the explosion sound
        explosionAudioSource.Play();
    }
}