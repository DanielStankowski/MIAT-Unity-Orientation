using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVashtiPlatform : MonoBehaviour
{
    public GameObject vashtiPlatform;


	void Start ()
    {
        Invoke("Platform", 7.5f);
	}
	
    void Platform ()
    {
        vashtiPlatform.SetActive(true);
    }
}