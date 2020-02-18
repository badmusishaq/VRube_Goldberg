using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;

	public float throwForce = 1.5f;

	//swipe
	public Vector2 swipeSum;
	public Vector2 touchLast;
	public Vector2 touchCurrent;
	public Vector2 distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;
	public ObjectMenuManager objectMenuManager;
	public GameObject objectMenu;
	//public TheGame theGame;

//	public float swipeSum;
//	public float touchLast;
//	public float touchCurrent;
//	public float distance;

	public SteamVR_LoadLevel loadLevel;



	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();

	}

	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
		if (device.GetTouchDown (SteamVR_Controller.ButtonMask.Touchpad))
		{
			
			touchLast = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0);
				//SteamVR_Touchpad);
				//.x;
		}
		if (device.GetTouch (SteamVR_Controller.ButtonMask.Touchpad))
		{
			touchCurrent = device.GetAxis (Valve.VR.EVRButtonId.k_EButton_Axis0);
				//SteamVR_Touchpad);
				//.x;
			distance = touchCurrent - touchLast;
			touchLast = touchCurrent;
			swipeSum += distance;

			objectMenu.SetActive (true);

			if (!hasSwipedRight)
			{
				if (swipeSum.x > 0.5f)
				{
					swipeSum.x = 0;
					SwipeRight ();
					hasSwipedRight = true;
					hasSwipedLeft = false;

				}
			}

			if (!hasSwipedLeft)
			{
				if (swipeSum.x < -0.5f)
				{
					swipeSum.x = 0;
					SwipeLeft ();
					hasSwipedLeft = true;
					hasSwipedRight = false;

				}
			}

		}

		if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Touchpad))
		{
			swipeSum.x = 0;
			touchCurrent.x = 0;
			touchLast.x = 0;
			hasSwipedLeft = false;
			hasSwipedRight = false;

			objectMenu.SetActive (false);
		}

		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad))
		{
			SpawnObject();
		}

	}
	void SpawnObject()
	{
		objectMenuManager.SpawnCurrentObject();

			
//			.SpawnFan ();
//		objectMenuManager.SpawnMetalPlank ();
//		objectMenuManager.SpawnTrampoline ();
//		objectMenuManager.SpawnWoodenPlank ();

	}
	void SwipeLeft ()
	{
		objectMenuManager.MenuLeft ();
	}

	void SwipeRight ()
	{
		objectMenuManager.MenuRight ();
	}

	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.CompareTag ("Throwable"))
		{
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger))
			{
				ThrowObject (col);
			}
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) 
			{
				GrabObject (col);			
			}
		}

		if (col.gameObject.CompareTag ("Restart"))
		{
			if (device.GetPress (SteamVR_Controller.ButtonMask.Trigger))
			{
				RestartGame ();
			}
		}

	}

	public void GrabObject (Collider coli)
	{
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody>().isKinematic = true;
		device.TriggerHapticPulse (2000);
	}

	public void ThrowObject (Collider coli)
	{
		coli.transform.SetParent (null);
		Rigidbody rigidbody = coli.GetComponent<Rigidbody> ();
		rigidbody.isKinematic = false;
		rigidbody.velocity = device.velocity * throwForce;
		rigidbody.angularVelocity = device.angularVelocity;
	}

	public void RestartGame ()
	{
		loadLevel.Trigger ();
	}
}
