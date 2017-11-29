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



	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.F1)) {
			ShowMapView ();
		}

		if (Input.GetKeyDown (KeyCode.F2)) {
			ShowFPView ();
			Vector3 vec = new Vector3 (2, 7, -25);
			ChangeCharacterPosition (vec);
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
		intructionText.text = "Place points to map, press F2 when ready";
		_ChangeHeight.change (15F);
		pointTypeIntroduction.text = "Mouse right click = Regular point \nMouse left click = POI";  
		
	}

	void ChangeCharacterPosition(Vector3 pos){
		//Debug.Log (character.transform.position);
		character.transform.position = pos;

	}




	




}
