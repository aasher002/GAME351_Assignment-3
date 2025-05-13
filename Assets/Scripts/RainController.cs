using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RainController : MonoBehaviour
{
    public float RainRate = 500f;

    private ParticleSystem rainSystem;
    private ParticleSystem.EmissionModule emission;

    void Start()
    {
        rainSystem = GetComponent<ParticleSystem>();
        emission = rainSystem.emission;
    }

    void Update()
    {
        emission.rateOverTime = RainRate;
    }
}
