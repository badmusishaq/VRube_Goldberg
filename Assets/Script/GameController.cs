using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public EndGame endGame;
	public TheGame theGame;
	public bool isCheating;

	private Vector3 playerPosition {
		get {
			return SteamVR_Render.Top().head.position;
		}
	}


	private void FindPlatform () {
		RaycastHit groundRay;
		if (Physics.Raycast (playerPosition, -Vector3.up, out groundRay)) {
			if (groundRay.collider.CompareTag ("ThrowArea")) {
				isCheating = false;
			}
			else if (!groundRay.collider.CompareTag ("Throwable")) {
				isCheating = true;
			}
		}
	}


}