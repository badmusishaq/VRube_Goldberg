using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

	public SteamVR_LoadLevel loadLevel;

	public void OnCollisionEnter ()
	{
		loadLevel.Trigger ();
	}


}