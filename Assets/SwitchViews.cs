using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchViews : MonoBehaviour
{

	public Text intructionText;
	public Text pointTypeIntroduction;
	public GameObject character;
	public ChangeHeight _ChangeHeight;
	public Image crosshair;

	public raycastscript _raycastscrip;

	void Start(){

	}
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.F1)) {
			ShowMapView ();
			_raycastscrip.MakeObjectVisible (false);

		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			ShowFPView ();
			if(_raycastscrip.first == false) {
				ChangeCharacterPosition (_raycastscrip.GetFirstPointPosition());
			}
			_raycastscrip.MakeObjectVisible (true);
		}

		if (Input.GetKeyDown (KeyCode.F3)) {
			_raycastscrip.DeletePoints ();
			_raycastscrip.first = true;

		}

		if (Input.GetKeyDown (KeyCode.F4)) {
        	_raycastscrip.pointAssistantOn = !_raycastscrip.pointAssistantOn;
        }
	}

	public void ShowFPView ()
	{

		intructionText.text = "";
		pointTypeIntroduction.text = "";
		_ChangeHeight.change (1.8F);
	}


	public void ShowMapView ()
	{
		intructionText.text = "Place points to map, press F2 when ready \nPress F3 to delete all the points\nPress F4 to toggle point assistant on/off";
		_ChangeHeight.change (18F);
		pointTypeIntroduction.text = "Mouse right click = Regular point \nMouse left click = POI";  
		crosshair.enabled = true;
		
	}

	void ChangeCharacterPosition(Vector3 pos){
		character.transform.position = pos;
		crosshair.enabled = false;

	}




	




}
