using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeight : MonoBehaviour
{
	public CharacterController controller;

	void Start ()
	{

		controller = GetComponent<CharacterController> ();
	
	}

	public void change (float charHeight)
	{
		controller.height = charHeight;

	}

}
