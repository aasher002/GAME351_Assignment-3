using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class TriggerDebug : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.name);
    }
}
