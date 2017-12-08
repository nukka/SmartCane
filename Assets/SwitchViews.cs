using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

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
		
			GamePad.SetVibration (0, 1f, 1f);


		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			ShowFPView ();
			ChangeCharacterPosition (_raycastscrip.GetFirstPointPosition());
			_raycastscrip.MakeObjectVisible (true);
		}

		if (Input.GetKeyDown (KeyCode.F3)) {
			_raycastscrip.DeletePoints ();

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
		intructionText.text = "Place points to map, press F2 when ready \nPress F3 to delete all the points";
		_ChangeHeight.change (15F);
		pointTypeIntroduction.text = "Mouse right click = Regular point \nMouse left click = POI";  
		crosshair.enabled = true;
		
	}

	void ChangeCharacterPosition(Vector3 pos){
		character.transform.position = pos;
		crosshair.enabled = false;

	}




	




}
