using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolver : MonoBehaviour {

	public Renderer rend;
	public float duration;
	public Material material1;

	public bool dissolving=true;

	public IEnumerator SetDissolve(){
		yield return new WaitForSeconds (3f);
		dissolving = false;
	//	rend.sharedMaterial.shader = Shader.Find ("Standard");
	//	GetComponent<Renderer>().sharedMaterial.CopyPropertiesFromMaterial(material1);
		//rend.sharedMaterial.SetFloat ("_Level", 0);
		//Shader.SetGlobalFloat("_Level",0);

	}

	// Use this for initialization
	void Start () {

		rend = gameObject.GetComponent<Renderer> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (dissolving) {

			StartCoroutine (SetDissolve ());

			duration += Time.deltaTime / 3;

			float disLev = Mathf.Lerp (1f, 0f, duration);
			rend.sharedMaterial.SetFloat ("_Level", disLev);

		}
		
	}
}
