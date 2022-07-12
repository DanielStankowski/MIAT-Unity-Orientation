using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposeLeafOrbit : MonoBehaviour
{
    private ParticleSystem.VelocityOverLifetimeModule psv;

    private ParticleSystem.MinMaxCurve orbitalZCurve;
    private ParticleSystem.MinMaxCurve gravCurve;

    private ParticleSystem.MainModule psm;

    public float orbitalZValue;
    public float radialValue;
    public float gravityValue;

    // Use this for initialization
    void Start ()
    {
        psv = GetComponent<ParticleSystem>().velocityOverLifetime;
        psm = GetComponent<ParticleSystem>().main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        orbitalZCurve.constant = orbitalZValue;
        psv.orbitalZ = orbitalZCurve;

        psv.radial = radialValue;

        gravCurve.constant = gravityValue;
        psm.gravityModifier = gravCurve;
    }
}
