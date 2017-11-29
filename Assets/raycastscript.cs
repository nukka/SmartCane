﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class raycastscript : MonoBehaviour
{
	public float range;
	public float rate;
	private float curRate;
	private bool canPlace;
	public Transform pointSpawn;
	public GameObject regularPoint;
	public GameObject pointOfInterest;
	public SwitchViews _SwitchViews;




	// Use this for initialization
	void Start ()
	{
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

		PlacePointType ();

	}

	void Shoot (GameObject pointType)
	{
		Ray ray = new Ray (pointSpawn.transform.position, pointSpawn.transform.forward);
		RaycastHit hit;
		Debug.Log ("Shot");

		if (Physics.Raycast (ray, out hit, range)) {
			Debug.Log ("Hit " + hit.collider.name);	
			Vector3 hitPoint = hit.point;
			hitPoint.y = 0.05F;
	

			PlacePoint (hitPoint, pointType);

		}
	
	}

	void PlacePoint (Vector3 objPosition, GameObject pointType)
	{
		Quaternion rotation = Quaternion.Euler (0, 0, 0);
		Instantiate (pointType, objPosition, rotation);

	}

	void PlacePointType(){
		if (Input.GetMouseButton (0)) {
			if (canPlace) {
				Shoot (regularPoint);
			}
		}

		if (Input.GetMouseButton (1)) {
			if (canPlace) {
				Shoot (pointOfInterest);
			}
		}
	}

}
