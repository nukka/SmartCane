using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastscript : MonoBehaviour
{
	public float range;
	public float fireRate;
	private float curFireRate;
	private bool canShoot;
	public Transform bulletSpawn;


	public GameObject typeOfPoint;



	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Starting");


	}
	
	// Update is called once per frame
	void Update ()
	{
		curFireRate -= Time.deltaTime;
		if (curFireRate <= 0) {
			canShoot = true;
			curFireRate = fireRate;
		} else {
			canShoot = false;
		}

		if (Input.GetButton ("Fire1")) {
			if (canShoot) {
				Shoot ();
			}
	
		}

	}

	void Shoot ()
	{
		Ray ray = new Ray (bulletSpawn.transform.position, bulletSpawn.transform.forward);
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

	public void talk(){
		//Vector3 vec = new Vector3 (0, 20, 0);
		Debug.Log ("moro");
	}

}
