using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDummy : MonoBehaviour {

	public GameObject Holo1Prefab;
	public GameObject HoloGramControl;
	public GameObject DissolverPrefab;

	public IEnumerator InstaDelay(){
		yield return new WaitForSeconds (0.2f);
		HoloGramControl.SetActive (true);
	}

	// Use this for initialization
	void Awake () {

		GameObject Holo1Inst = Instantiate(Holo1Prefab, gameObject.transform.position,gameObject.transform.rotation,null);
	//	GameObject dissolverinst =  Instantiate(DissolverPrefab, gameObject.transform.position,Quaternion.identity,null);
		HoloGramControl = Holo1Inst.transform.GetChild (1).gameObject;
		StartCoroutine (InstaDelay ());
		//Application.targetFrameRate = 30;

	}
	
	// Update is called once per frame
	void Update () {


		
	}
}
