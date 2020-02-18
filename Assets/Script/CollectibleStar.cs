using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleStar : MonoBehaviour {
	private GameObject collectibleStar;
	public int numberOfCollectibles;
	public TheGame theGame;
	AudioSource audioSource;


	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}


	void OnCollisionEnter (Collision co)
	{
		if (co.gameObject.CompareTag ("Throwable")) // && co.gameObject.layer == 10)
		{
			audioSource.Play ();
			gameObject.SetActive (false);
		}
		theGame.CollectStar ();
	}

}

