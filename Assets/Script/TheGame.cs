using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGame : MonoBehaviour {



	public static int level = 1;

	public GameObject fanPrefab;
//	public int numberOfFans = 0;
//	public List<GameObject> fans;
//	public int fansUsed = 0;

	public GameObject metalPlankPrefab;
//	public int numberOfMetalPlanks = 0;
//	public List<GameObject> metalPlanks;
//	public int metalPlanksUsed = 0;

	public GameObject trampolinePrefab;
//	public int numberOfTrampolines = 0;
//	public List<GameObject> trampolines;
//	public int trampolinesUsed = 0;

	public GameObject woodenPlankPrefab;
//	public int numberOfWoodenPlanks = 0;
//	public List<GameObject> woodenPlanks;
//	public int woodenPlanksUsed = 0;


	public List<CollectibleStar> stars;
	public int starsCollected = 0;


	public void CollectStar () {
		starsCollected++;
	}

	public void ResetStars () {
		
		foreach (CollectibleStar star in stars)
		{
			star.gameObject.SetActive (true);
			starsCollected = 0;
		}

	}
}