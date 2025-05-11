using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SupplyStoreTrigger : MonoBehaviour
{
    public MusicManager musicManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered supply store trigger.");
            if (musicManager != null)
                musicManager.PlaySuspense();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited supply store trigger.");
            if (musicManager != null)
                musicManager.PlayDefault();
        }
    }
}