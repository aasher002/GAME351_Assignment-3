using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDrift : MonoBehaviour
{
    public Vector3 driftDirection = new Vector3(1f, 0f, 0f);
    public float speed = 1f;

    public float loopDistance = 200f;   
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position += driftDirection * speed * Time.deltaTime;

        float traveled = Vector3.Dot(transform.position - startPosition, driftDirection.normalized);

        if (traveled > loopDistance)
        {
            transform.position = startPosition;
        }
    }
}
