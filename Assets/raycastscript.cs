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
	public GameObject regularPoint;
	public GameObject pointOfInterest;
	public SwitchViews _SwitchViews;

	private int count = 0;
	private GameObject firstPoint;

	public Renderer rend;



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


	private Vector3 hitPoint = new Vector3 (0, 0, 0);

	void Shoot (GameObject pointType)
	{
		Ray ray = new Ray (pointSpawn.transform.position, pointSpawn.transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, range)) {
			Debug.Log ("Hit " + hit.collider.name);	
			hitPoint = hit.point;
			hitPoint.y = 0.05F;

			CreatePoint (hitPoint, pointType);


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

	public void MakeObjectVisible(bool b){
		rend = GetComponent<Renderer>();
		rend.enabled = b;
	}


}
