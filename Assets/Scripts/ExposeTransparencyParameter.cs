using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposeTransparencyParameter : MonoBehaviour
{
    public float alphaFloat = 125;
    //public Material myMaterial;

    public Material[] myMaterials;


	// Use this for initialization
	void Start ()
    {
        //myMaterial = GetComponent<Renderer>().material;
        myMaterials = GetComponent<Renderer>().materials;

    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Material m in myMaterials)
        {
            m.SetColor("_Color", new Vector4(m.color.r, m.color.g, m.color.b, alphaFloat / 255));
        }

        //myMaterial.SetColor("_Color", new Vector4(myMaterial.color.r, myMaterial.color.g, myMaterial.color.b, alphaFloat/255));
	}
}
