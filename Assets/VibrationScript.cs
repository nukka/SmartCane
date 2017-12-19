using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour {

	public VibrationPattern _VibrationPattern;

	IEnumerator OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "RegularPoint") {
			GamePad.SetVibration (0, 0.4f, 0.4f);
			yield return new WaitForSeconds(0.2f);
			GamePad.SetVibration (0, 0f, 0f);
		}	
		if (collision.collider.tag == "POI") {
			GamePad.SetVibration (0, 1f, 1f);
			yield return new WaitForSeconds(0.1f);
			GamePad.SetVibration (0, 0f, 0f);
			yield return new WaitForSeconds(0.1f);
			GamePad.SetVibration (0, 1f, 1f);
			yield return new WaitForSeconds(0.5f);
			GamePad.SetVibration (0, 0f, 0f);
		}	
	}

	IEnumerator OnCollisionStay (Collision collision) {
		//if (collision.collider.tag == "RegularPoint") {
			//_VibrationPattern.Vibrate(0, 0.5f, 0.2f);
		//}	
		if (collision.collider.tag == "RegularPoint") {
			GamePad.SetVibration (0, 0.4f, 0.4f);
			yield return new WaitForSeconds(0.2f);
			GamePad.SetVibration (0, 0f, 0f);
		}	
		if (collision.collider.tag == "POI") {
			GamePad.SetVibration (0, 1f, 1f);
			yield return new WaitForSeconds(0.1f);
			GamePad.SetVibration (0, 0f, 0f);
			yield return new WaitForSeconds(0.1f);
			GamePad.SetVibration (0, 1f, 1f);
			yield return new WaitForSeconds(0.5f);
			GamePad.SetVibration (0, 0f, 0f);
		}	

	}

}
