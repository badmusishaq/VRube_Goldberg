using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

	private float thrust = 750f;
	AudioSource audiosource;

	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
		
	}
	
	void OnCollisionEnter (Collision met)
	{ Rigidbody rb = met.gameObject.GetComponent<Rigidbody> ();
		if (rb.gameObject.CompareTag ("Throwable"))
		{
			rb.AddForce (transform.forward * thrust, ForceMode.Acceleration);

			audiosource.Play ();

		}
			
	}
}