using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRing : MonoBehaviour
{
    public float delayTime;
    public GameObject segment;

	void Start ()
    {
		for (int i = 0; i <36; i++)
        {
            GameObject newSegment = Instantiate(segment, transform.position, Quaternion.identity * Quaternion.Euler(-30, 10 * i, 0));
            StartCoroutine(Align(newSegment.GetComponent<Animator>(), i * delayTime));
        }
	}

    IEnumerator Align(Animator a, float f)
    {
        yield return new WaitForSeconds(f);
        a.SetTrigger("Align");
    }
}
