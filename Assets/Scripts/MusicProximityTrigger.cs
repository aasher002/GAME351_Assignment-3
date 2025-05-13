using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicProximityTrigger : MonoBehaviour
{
    public MusicManager musicManager;  // Reference to the MusicManager
    public Transform supplyStore;      // Reference to the supply store's position

    public float enterDistance = 10f;  // Distance to start suspense music
    public float exitDistance = 12f;   // Distance to stop suspense music

    private bool isInSuspenseZone = false;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, supplyStore.position);
        Debug.Log("Distance to Supply Store: " + distance);

        if (!isInSuspenseZone && distance < enterDistance)
        {
            musicManager.PlaySuspense();
            isInSuspenseZone = true;
        }
        else if (isInSuspenseZone && distance > exitDistance)
        {
            musicManager.PlayDefault();
            isInSuspenseZone = false;
        }
    }
}