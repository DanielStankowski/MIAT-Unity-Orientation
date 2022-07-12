using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorw : MonoBehaviour {


    public GameObject rock;
    public Transform Player;



    public void  ThrowRock()
    {
       var RO = Instantiate(rock, Player.position + (transform.forward * 0.1f), Player.rotation);
	//	var RO = Instantiate(rock, Player.position, Player.rotation);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
