﻿/*
 * This Class handles flipping the global _StencilTest property when the device
 * moves throught the portal, from any direction
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{

    public Transform device;
	public MeshRenderer PortalMesh;
	public GameObject PortalExit;
	//public GameObject PortalExitFrame;
	public GameObject PrevSwitch;
	public GameObject NextSwitch;

	public Material[] materials;




    //bool for checking if the device is not in the same direction as it was
    bool wasInFront;
    //bool for knowing that on the next change of state, what to set the stencil test
   public bool inOtherWorld;

    //This bool is on while device colliding, done so we ensure the shaders are being updated before render frames
    //Avoids flickering
    bool isColliding;

	public IEnumerator DelayChangeMat(){


		SetMaterials (true);

		yield return new WaitForEndOfFrame ();

		PortalMesh.enabled = false;
		yield return new WaitForEndOfFrame ();
		PortalMesh.enabled = true;


	}

	public IEnumerator DelayFrame (GameObject FR){

		yield return new WaitForSeconds (0.7f);
		FR.SetActive (true);
	}



    void Awake()
    {
        //start outside other world
       SetMaterials(false);

		PortalMesh = this.gameObject.GetComponent<MeshRenderer> ();
	//	GameObject cam =  GameObject.FindGameObjectWithTag ("MainCamera");
	//	device = cam.transform;

    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;

      //  Shader.SetGlobalInt("_StencilTest", (int)stencilTest);

		foreach (var mat in materials) {
			mat.SetInt ("_StencilTest", (int)stencilTest);
		}

	

    }

    bool GetIsInFront()
    {
		Vector3 worldPos = device.position + device.forward * (Camera.main.nearClipPlane*4);

        Vector3 pos = transform.InverseTransformPoint(worldPos);
        return pos.z >= 0 ? true : false;
	
    }


    //This technique registeres if the device has hit the portal, flipping the bool

    void OnTriggerEnter(Collider other)
    {
        if (other.transform != device)
            return;
        //Important to do this for if the user re-enters the portal from the same side
        wasInFront = GetIsInFront();
		PortalExit.SetActive (true);
		PrevSwitch.SetActive (false);


			


	//	PortalExit.GetComponent<MeshRenderer>().enabled = true;

	//	StartCoroutine(DelayFrame(PortalExitFrame));
        isColliding = true;

    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform != device)
            return;
		

		isColliding = false;
		NextSwitch.SetActive (true);
    }


    /*If there has been a change in the relative position of the device to the portal, flip the
     *Stencil Test
     */

    void WhileCameraColliding()
    {
        if (!isColliding)
            return;
        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
			//SetMaterials(true);
        }
        wasInFront = isInFront;
    }

    void OnDestroy()
    {
        //ensure geometry renders in the editor
        SetMaterials(true);
    }


    void Update()
    {
        WhileCameraColliding();
    }
}
