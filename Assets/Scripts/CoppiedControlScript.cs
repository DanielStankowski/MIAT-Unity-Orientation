using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoppiedControlScript : MonoBehaviour {

    public GameObject Holo1;
    public GameObject Hologram1;
    public GameObject Holo2Prefab;
    public GameObject Holo3Prefab;
    public GameObject Holo4Prefab;
  
   
    public GameObject VashtiMarker;
  
    public float MusicTrackDelay;

    public float Part1Delay;
    public float Part2Delay;
    public float Part3Delay;
    public float Part4Delay;

    void Awake()
    {
        StartCoroutine(VidLoad(Part1Delay,Part2Delay,Part3Delay,Part4Delay));
    }




    public IEnumerator VidLoad(float p1, float p2, float p3, float p4)
    {
        yield return new WaitForSeconds(p1);
        Hologram1.SetActive(true);
        yield return new WaitForSeconds(p2);
        GameObject Holo2Inst = Instantiate(Holo2Prefab, Hologram1.transform.position, Quaternion.identity,Holo1.transform);
        yield return new WaitForSeconds(0.2f);
        Destroy(Hologram1);
        yield return new WaitForSeconds(p3);
        GameObject Holo3Inst = Instantiate(Holo3Prefab, Holo2Inst.transform.position, Quaternion.identity,Holo1.transform);
        Holo3Inst.SetActive(true);
        yield return new WaitForSeconds(9.3f);
        Destroy(Holo2Inst);
        yield return new WaitForSeconds(p4);
        GameObject Holo4Inst = Instantiate(Holo4Prefab, Holo3Inst.transform.position, Quaternion.identity, Holo1.transform);
        Holo4Inst.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(Holo3Inst);
        yield return new WaitForSeconds(44.7f);
        Destroy(Holo4Inst);
        Destroy(Holo1);
        Destroy(Hologram1);

    

    }
}