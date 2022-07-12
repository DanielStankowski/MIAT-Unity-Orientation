using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsynchronusLoading : MonoBehaviour {

	public IEnumerator loadaysnc(){

		yield return new WaitForSeconds (2f);

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (1);
		while (!asyncLoad.isDone) {
			yield return null;

		}

	}

	// Use this for initialization
	void Start () {

		StartCoroutine (loadaysnc ());

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
