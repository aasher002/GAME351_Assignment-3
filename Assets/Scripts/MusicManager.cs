using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public AudioClip defaultTrack;
    public AudioClip suspenseTrack;
    public AudioClip fightTrack;

    private AudioSource audioSource;
    private string currentTrack = "Default";
    private float lastSwitchTime = 0f;
    public float switchCooldown = 2f; // prevents spam switching
    

    public GameObject player; // Reference to the player

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayTrack("Default");
    }

    void PlayTrack(string trackName)
    {
        if (Time.time - lastSwitchTime < switchCooldown) return;
        if (trackName == currentTrack) return;

        lastSwitchTime = Time.time;
        currentTrack = trackName;

        switch (trackName)
        {
            case "Default":
                audioSource.clip = defaultTrack;
                break;
            case "Suspense":
                audioSource.clip = suspenseTrack;
                break;
            case "Fight":
                audioSource.clip = fightTrack;
                break;
        }

        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayDefault()
    {
        PlayTrack("Default");
    }

    public void PlaySuspense()
    {
        PlayTrack("Suspense");
    }

    public void PlayFight()
    {
        PlayTrack("Fight");
    }

    public string GetCurrentTrack()
    {
        return currentTrack;
    }

    // Detect the player entering the proximity of the Supply Store
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaySuspense();
        }
    }

    // Detect the player exiting the proximity of the Supply Store
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayDefault();
        }
    }
}