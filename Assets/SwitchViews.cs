using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchViews : MonoBehaviour
{
	public Camera FPView;
	public Camera MapView;
	public Text intructionText;



	void Update ()
	{

		
		if (Input.GetKeyDown (KeyCode.F1)) {
			ShowMapView ();

			Vector3 vec = new Vector3 (0, 20, 0);
			intructionText.text = "Place points to map, press F2 to return";
	
			//characterPosition.transform.position += vec;


		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			ShowFPView ();
			intructionText.text = "";
		}
	}

	public void ShowFPView ()
	{
		FPView.enabled = true;
		MapView.enabled = false;
		
	}
	
	// Update is called once per frame
	public void ShowMapView ()
	{
		MapView.enabled = true;
		FPView.enabled = false;
		
	}




}
