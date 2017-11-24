using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIscript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI ()
	{
		GUI.Box (new Rect (0, 0, 80, 20), "Test");
	}


	public void writeSomething(){
		Debug.Log ("testing");
		
	}


}
