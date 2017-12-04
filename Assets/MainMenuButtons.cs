using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenuButtons : MonoBehaviour {


	public void StartBtn (string NewSimulationLevel) {
		Handheld.Vibrate ();
		SceneManager.LoadScene (NewSimulationLevel);
		
	}

	public void quitBtn() {
		Application.Quit ();
	}


	

}
