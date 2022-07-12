using UnityEngine; 
using System.Collections;

public class KineticClick: MonoBehaviour {
	
	Rigidbody m_Rigidbody;

	void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		//
	}
	void Update()
	{
		//Press space to add constraints on the RigidBody (Freezing the position)
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Freeze all positions
			m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePosition;
			m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotation;
		}
	}
}