using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour {
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "RegularPoint") {
			GamePad.SetVibration (0, 0.2f, 0.2f);
		}	
		if (collision.collider.tag == "POI") {
			GamePad.SetVibration (0, 1f, 1f);
		}	
	}

	void OnCollisionStay (Collision collision) {
		if (collision.collider.tag == "RegularPoint") {
			GamePad.SetVibration (0, 0.2f, 0.2f);
		}	
		if (collision.collider.tag == "POI") {
			GamePad.SetVibration (0, 1f, 1f);
		}	
	}



}
