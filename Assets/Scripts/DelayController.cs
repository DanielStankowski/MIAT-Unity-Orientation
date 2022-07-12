using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayController : MonoBehaviour
{
    public float waitTime;
    public GameObject[] emitterGOs;


	// Use this for initialization
	void Start ()
    {
        Invoke("Emit", waitTime);
	}
	
	void Emit ()
    {
        foreach (GameObject g in emitterGOs)
        {
            g.SetActive(true);
        }
    }
}
