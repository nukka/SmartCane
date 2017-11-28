using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastscript : MonoBehaviour
{
	public float range;
	public float rate;
	private float curRate;
	private bool canPlace;
	public Transform pointSpawn;
	public GameObject typeOfPoint;
	public SwitchViews _SwitchViews;



	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Starting");
		_SwitchViews.ShowMapView ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		curRate -= Time.deltaTime;
		if (curRate <= 0) {
			canPlace = true;
			curRate = rate;
		} else {
			canPlace = false;
		}

		if (Input.GetButton ("Fire1")) {
			if (canPlace) {
				Shoot ();
			}
	
		}

	}

	void Shoot ()
	{
		Ray ray = new Ray (pointSpawn.transform.position, pointSpawn.transform.forward);
		RaycastHit hit;
		Debug.Log ("Shot");

		if (Physics.Raycast (ray, out hit, range)) {
			Debug.Log ("Hit " + hit.collider.name);	
			Vector3 hitPoint = hit.point;
			hitPoint.y = 0.05F;

			Place (hitPoint);
		}
	
	}

	void Place (Vector3 objPosition)
	{
		Quaternion rotation = Quaternion.Euler (0, 0, 0);
		Instantiate (typeOfPoint, objPosition, rotation);
	}

}
