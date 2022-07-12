using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafParticleEmitter : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue;

    private float hSliderOffset;

    public float startDelay;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        startDelay = ps.main.startDelay.constant;
        Debug.Log(this.gameObject + " " + ps.main.startDelay.constant);
        Invoke("AnimatorOn", startDelay);
       
        /*
        ParticleSystem.Particle[] pArray = new ParticleSystem.Particle[ps.main.maxParticles];

        baseColor = leafMat.GetColor("_Color");
        hSliderOffset = hSliderValue;
        */
    }

    void AnimatorOn ()
    {
        if (GetComponent<Animator>())
        {
            GetComponent<Animator>().enabled = true;
        }
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;
    }
}