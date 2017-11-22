using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	public GameObject cube;
	// Use this for initialization
	void Start ()
	{
		spawn ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
	}

	void spawn ()
	{
		transform.position = new Vector3 (0, 1, 3);
		Instantiate (cube, transform.position, transform.rotation);
	
		

	}
}
