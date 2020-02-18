using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArea : MonoBehaviour {
	public bool isOut;
	private Renderer areaRenderer;
	private Material areaMaterial;
	public GameObject ball;

	// Use this for initialization
	void Start () {
		areaRenderer = GetComponent<Renderer>();
		areaMaterial = areaRenderer.material;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<Collider>().CompareTag ("Detector"))
		{
			areaMaterial.color = Color.blue;
		}
		isOut = false;
		ball.layer = 10;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Collider>().CompareTag ("Detector"))
		{
			areaMaterial.color = Color.red;
		}
		isOut = true;
		ball.layer = 9;
	}
}
