﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class raycastscript : MonoBehaviour
{
	public const double pointDistance = 2;
	public float range;
	public float rate;
	private float curRate;
	private bool canPlace;
	public Transform pointSpawn;
	private Vector3 hitPoint = new Vector3 (0, 0, 0);
	public GameObject regularPoint;
	public GameObject pointOfInterest;
	public SwitchViews _SwitchViews;
	public Renderer rend;
	private int count = 0;
	private GameObject firstPoint;
	public bool first = true;
	public bool pointAssistantOn = true;
	private Vector3 prevPoint = new Vector3 (0, 0, 0);
	private Vector3 middlePoint = new Vector3 (0, 0, 0);


	// Use this for initialization
	void Start ()
	{
		_SwitchViews.ShowMapView ();
		MakeObjectVisible (false);

	
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
	
		if (Physics.Raycast (ray, out hit, range)) {
			//Debug.Log ("Hit " + hit.collider.name);	
			hitPoint = hit.point;
			hitPoint.y = 0.05F;

			CreatePoint (hitPoint, pointType);

			if (!first & pointAssistantOn) {
				PlacePointsBetweenPoints ();
			}

			first = false;
			prevPoint = hitPoint;

		}
	
	}

	void CreatePoint (Vector3 objPosition, GameObject pointType)
	{
		Quaternion rotation = Quaternion.Euler (0, 0, 0);
		GameObject point = Instantiate (pointType, objPosition, rotation);

		if (pointType.gameObject.name == "RegularPoint") {
			point.gameObject.tag = "RegularPoint";
		}

		if (pointType.gameObject.name == "PointOfInterest") {
			point.gameObject.tag = "POI";
		}


		CreateID (point);

	}

	void PlacePointType ()
	{
		if (!canPlace) {
			return;
		}

		GameObject[] pointTypes = { regularPoint, pointOfInterest };
		int len = pointTypes.Length;
		for (int i = 0; i < len; ++i) {
			if (Input.GetMouseButton (i)) {
				Shoot (pointTypes [i]);
			}
		}
	}

	public void CreateID (GameObject point)
	{
		point.name = "rPoint" + count;
		Debug.Log (point.name);
		count++;

	}

	public Vector3 GetFirstPointPosition ()
	{
		firstPoint = GameObject.Find ("rPoint0");
		return firstPoint.transform.position;
	}

	public void DeletePoints ()
	{
		first = true;
		count = 0;
		GameObject[] allPts;

		GameObject[] regPts = GameObject.FindGameObjectsWithTag ("RegularPoint");
		GameObject[] poiPts = GameObject.FindGameObjectsWithTag ("POI");
		allPts = regPts.Concat (poiPts).ToArray ();

		for (int i = 0; i < allPts.Length; i++) {
			Destroy (allPts [i]);
		}
	}

	public void MakeObjectVisible (bool b)
	{
		rend = GetComponent<Renderer> ();
		rend.enabled = b;

	}

	void PlacePointsBetweenPoints ()
	{

		float distance = 0;
		float linePositionLength;
		float linePosition;

		distance = Vector3.Distance (prevPoint, hitPoint);
		int pointCount = (int)Math.Ceiling (distance / pointDistance);

		linePositionLength = 1 / (float)pointCount;
		linePosition = linePositionLength;
		//Debug.Log ("line pos length: " + linePositionLength + " and pointCount: " + pointCount);

		for (int i = 0; i <= pointCount - 1; i++) {

			middlePoint = Vector3.Lerp (prevPoint, hitPoint, linePosition);
			//Debug.Log ("line pos: " + linePosition + "and i: " + i);
			linePosition += linePositionLength;
			CreatePoint (middlePoint, regularPoint);
		}
	}

}
