using System;
using System.Collections;
using System.IO;
#if (NET_4_6 || USE_ASYNC)
using System.Threading;
using System.Threading.Tasks;
#endif
using UnityEngine;
using UnityEngine.Rendering;

public class HoloGramControl : MonoBehaviour{

	public Component  HoloScript;

	public string[] VideoPaths;


	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
