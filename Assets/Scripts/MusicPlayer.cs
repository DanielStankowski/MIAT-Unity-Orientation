using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


	public AudioSource AP;
	private float TDelay;
	public GameObject Controller;


	public IEnumerator MusicDelay(){

		yield return new WaitForSeconds (TDelay);
		AP.Play ();

	}
	// Use this for initialization
	void Awake () {

	

		TDelay = Controller.GetComponent<CoppiedControlScript> ().MusicTrackDelay;

		StartCoroutine (MusicDelay ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
