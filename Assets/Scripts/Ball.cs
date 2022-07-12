using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {


	public float thrust = 0f;
	public Rigidbody rb;
	private GameObject Power;
	private Text PowerText;
	public bool Release = false;
	public float ForceCount;
	public Vector3 BallDirection;
	public bool ballhit = false;

	public GameObject ArrowPrefab;
	private GameObject ArInst;

	public GameObject PG;
	public bool EnablePG=false;

	public bool Shrink = false;

	public bool PuttMode = false;

	public IEnumerator ReplayDelay(){

		yield return new WaitForSeconds (5f);

		thrust = 0f;
		PowerText.text = ("Power:" + thrust);
		rb.isKinematic = true;
		//ArInst = Instantiate (ArrowPrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
		ballhit = false;
		Shrink = true;
		yield return new WaitForSeconds (3f);
		PG.SetActive (true);
		EnablePG = true;
		yield break;





	}


	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Green") {

			PuttMode = true;
		}
	}

	public void AddForce(){


			rb.isKinematic = false;

		rb.AddForce (transform.forward * (thrust*0.2f));
		rb.AddForce (transform.up * (thrust*0.5f));
		ballhit = true;
		StartCoroutine (ReplayDelay ());
	}

	public void PuttForce(){

		rb.isKinematic = false;

		rb.AddForce (transform.forward * (thrust * 5f));

		ballhit = true;
		StartCoroutine (ReplayDelay ());

	}




	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		Power = GameObject.FindGameObjectWithTag ("Power");
		PowerText = Power.GetComponent<Text> ();
	//	ArInst = Instantiate (ArrowPrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), Quaternion.identity);
	//	ArInst.transform.LookAt (this.gameObject.transform);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (ballhit == false) {
			BallDirection = Camera.main.transform.forward;
			gameObject.transform.forward = BallDirection;


		}

		if (Shrink) {
			transform.parent.parent.localScale= Vector3.Lerp (transform.parent.parent.localScale,Vector3.zero,Time.deltaTime*2f);
		}

		if (EnablePG) {
			
			PG.transform.localScale = Vector3.Lerp (transform.parent.parent.localScale,Vector3.one,Time.deltaTime*1f);
			if (PG.transform.localScale == (Vector3.one)) {
				EnablePG = false;
			
			}
		}
		if ((Input.GetMouseButton (0))&&(ballhit ==false)) {

			thrust++;
			PowerText.text = ("Power:" + thrust);

			//AddForce ();

		}

		if ((Input.GetMouseButtonUp (0))&&(ballhit == false)){

			if (PuttMode == false) {

				Destroy (ArInst);
				AddForce ();

			} else {

				Destroy (ArInst);
				PuttForce ();
			}

		}
		
	}
}
