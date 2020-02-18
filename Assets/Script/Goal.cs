using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	AudioSource audioSource;
	public GameController gameController;

	public SteamVR_LoadLevel loadLevel;
	public GameObject restartCanvas;
	public TheGame theGame;
	public ThrowArea throwArea;
	public ballReset _ballReset;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision ent)
	{
		if (ent.gameObject.CompareTag ("Throwable") && ent.gameObject.layer == 10)
			{

		//if ((theGame.starsCollected == theGame.stars.Count) && (!gameController.isCheating))
			if ((theGame.starsCollected == theGame.stars.Count) && (!throwArea.isOut))
			{
				audioSource.Play ();
				loadLevel.Trigger ();
				restartCanvas.gameObject.SetActive (true);

			}

		}
		else if (ent.gameObject.CompareTag ("Throwable") && ent.gameObject.layer == 9)
			{
				_ballReset.OnCollisionEnter (ent);
			}
	}
}