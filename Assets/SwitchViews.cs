using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchViews : MonoBehaviour
{

	public Text intructionText;
	public GameObject character;
	public ChangeHeight _ChangeHeight;



	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.F1)) {
			ShowMapView ();
		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			ShowFPView ();
		}
	}

	public void ShowFPView ()
	{

		intructionText.text = "";
		_ChangeHeight.change (1.8F);
	}


	public void ShowMapView ()
	{
		intructionText.text = "Place points to map, press F2 to return";
		_ChangeHeight.change (15F);
		
	}


	




}
