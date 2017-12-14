using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using Rewired;

public class VibrationScript : MonoBehaviour {

	public VibrationPattern _VibrationPattern;

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "RegularPoint") {
			//GamePad.SetVibration (0, 0.2f, 0.2f);
			_VibrationPattern.Vibrate(0, 0.5f, 0.5f);

		}	
		if (collision.collider.tag == "POI") {
			//GamePad.SetVibration (0, 1f, 1f);
	
			_VibrationPattern.Vibrate(0, 1f, 0.5f);
		}	
	}

	void OnCollisionStay (Collision collision) {
		if (collision.collider.tag == "RegularPoint") {
			//GamePad.SetVibration (0, 0.2f, 0.2f);
			_VibrationPattern.Vibrate(0, 0.5f, 0.5f);
		}	
		if (collision.collider.tag == "POI") {
			//GamePad.SetVibration (0, 1f, 1f);
			_VibrationPattern.Vibrate(0, 1f, 0.5f);
		}	
	}



}
