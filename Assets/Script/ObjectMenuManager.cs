using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {

	public List<GameObject> objectList;
	public List<GameObject> objectPrefabList;

	public int currentObject = 0;

	//public GameObject fanPrefab;
	public List<GameObject> fan;
	public int numberOfFan = 0;
	public int fansUsed = 0;

	//public GameObject metalPlankPrefab;
	public List<GameObject> MetalPlank;
	public int numberOfMetalPlank = 0;
	public int MetalPlanksUsed = 0;

	//public GameObject woodenPlankPrefab;
	public List<GameObject> woodenPlank;
	public int numberOfWoodenPlank = 0;
	public int woodenPlanksUsed = 0;

	//public GameObject trampolinePrefab;
	public List<GameObject> trampoline;
	public int numberOfTrampoline = 0;
	public int trampolinesUsed = 0;

	public TheGame theGame;



	// Use this for initialization
	void Start ()
	{

		foreach (Transform child in transform)
		{
			objectList.Add (child.gameObject);
		}

	}

	public void MenuLeft ()
	{
		objectList [currentObject].SetActive (false);
		currentObject--;
		if (currentObject < 0)
		{
			currentObject = objectList.Count - 1;
		}
		objectList [currentObject].SetActive (true);
	}

	public void MenuRight ()
	{
		objectList [currentObject].SetActive (false);
		currentObject++;
		if (currentObject > objectList.Count - 1)
		{
			currentObject = 0;
		}
		objectList [currentObject].SetActive (true);
	}

	public void SpawnCurrentObject ()
	{
		Instantiate (objectPrefabList [currentObject], objectList [currentObject].transform.position, objectList [currentObject].transform.rotation);
	}


	public GameObject SpawnMetalPlank ()
	{
		if (MetalPlanksUsed < numberOfMetalPlank)
			{
			GameObject MPlank =  Instantiate (MetalPlank [MetalPlanksUsed], objectList [MetalPlanksUsed].transform.position, objectList [MetalPlanksUsed].transform.rotation);
			MetalPlanksUsed++;
			return MPlank;
			}
		return null;
	}

	public GameObject SpawnFan ()
	{
		if (fansUsed < numberOfFan)
		{
			GameObject Faan = Instantiate (fan [fansUsed], objectList [fansUsed].transform.position, objectList [fansUsed].transform.rotation);
			fansUsed++;
			return Faan;
		}

		return null;
	}

	public GameObject SpawnTrampoline ()
	{
		if (trampolinesUsed < numberOfTrampoline)
		{
			GameObject Trampo =	Instantiate (trampoline [trampolinesUsed], objectList [trampolinesUsed].transform.position, objectList [trampolinesUsed].transform.rotation);
			trampolinesUsed++;
			return Trampo;
		}
		return null;
	}

	public GameObject SpawnWoodenPlank ()
	{
		if (woodenPlanksUsed < numberOfWoodenPlank)
		{
			GameObject WPlank =	Instantiate (woodenPlank [woodenPlanksUsed], objectList [woodenPlanksUsed].transform.position, objectList [woodenPlanksUsed].transform.rotation);
			woodenPlanksUsed++;
			return WPlank;
		}
		return null;
	}
}
