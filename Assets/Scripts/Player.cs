using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {
    
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage() {
        Debug.Log("take damage");
        
        string file = Random.Range(1, 23).ToString();
        audioSource.clip = Resources.Load<AudioClip>("Damage Sounds/" + file);
        
        audioSource.Play();
    }
}
