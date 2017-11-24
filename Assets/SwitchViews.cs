using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchViews : MonoBehaviour {
	public Camera FPSView;
	public Camera MapView;


	public void ShowFPSView () {
		FPSView.enabled = true;
		MapView.enabled = false;
		
	}
	
	// Update is called once per frame
	public void ShowMapView () {
		MapView.enabled = true;
		FPSView.enabled = false;
		
	}


}
