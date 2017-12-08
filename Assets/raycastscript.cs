using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
	bool first = true;


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


		Debug.Log (pointSpawn.transform.position);
		if (Physics.Raycast (ray, out hit, range)) {
			Debug.Log ("Hit " + hit.collider.name);	
			hitPoint = hit.point;
			hitPoint.y = 0.05F;

			CreatePoint (hitPoint, pointType);

			if (!first) {
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
		point.gameObject.tag = "Point";
		CreateID (point);

	}

	void PlacePointType ()
	{
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
		GameObject[] listOfPoints;

		listOfPoints = GameObject.FindGameObjectsWithTag ("Point");

		for (int i = 0; i < count; i++) {
			Destroy (listOfPoints [i]);
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
		Debug.Log ("line pos length: " + linePositionLength + " and pointCount: " + pointCount);

		for (int i = 0; i <= pointCount; i++) {

			middlePoint = Vector3.Lerp (prevPoint, hitPoint, linePosition);
			Debug.Log ("line pos: " + linePosition + "and i: " + i);
			linePosition += linePositionLength;
			CreatePoint (middlePoint, regularPoint);
		}
	}
}
