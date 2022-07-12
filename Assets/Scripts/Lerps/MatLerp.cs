using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatLerp : MonoBehaviour {

	public Material material1;
	//public Material material2;
	public float duration = 2.0F;
	public Renderer rend;

	public IEnumerator MaterialChange(){
		yield return new WaitForSeconds (3f);
		rend.sharedMaterial.shader = Shader.Find ("Standard");
		GetComponent<Renderer>().sharedMaterial.CopyPropertiesFromMaterial(material1);

	}


	void Start() {
		rend = GetComponent<Renderer>();
		StartCoroutine (MaterialChange ());//rend.material = material1;

	}
	void Update() {

	}
}