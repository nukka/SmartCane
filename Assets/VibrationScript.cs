using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour {
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Point") {
			GamePad.SetVibration (0, 0.2f, 0.2f);
		}		
	}

	void OnCollisionStay (Collision collision) {
		if (collision.collider.tag == "Point") {
			GamePad.SetVibration (0, 0.2f, 0.2f);
		}	
	}



}
