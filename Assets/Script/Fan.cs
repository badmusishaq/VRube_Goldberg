using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

	void OnCollisionStay(Collision breeze)
	{
		if (breeze.collider.CompareTag ("Throwable"))	
		{
			breeze.rigidbody.AddForce (transform.forward * 100f);
		}
	}
}
