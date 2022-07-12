using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevPortal : MonoBehaviour {

	public GameObject Halo;
	public GameObject Halo2;
	public GameObject Portal2;
	public GameObject RevPortal2;
	public GameObject Portal1;
	public GameObject RevPortal1;
	public GameObject Halo2Sky;


	void OnTriggerEnter(Collider other)
	{
		
			Halo.SetActive (false);


		Halo2.GetComponent<MeshRenderer>().enabled= true;
		Halo2Sky.GetComponent<MeshRenderer>().enabled= true;

		Portal2.SetActive (true);
		RevPortal2.SetActive (true);
		Portal1.SetActive (false);
		RevPortal1.SetActive (false);


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
