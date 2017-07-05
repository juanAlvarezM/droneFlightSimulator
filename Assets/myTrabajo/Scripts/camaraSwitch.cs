using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraSwitch : MonoBehaviour {

	public Camera camara1;
	public Camera camara2;
	public GameObject ourDrone;

	void setup()
	{
		
		camara1.enabled = true;
		camara2.enabled = false;
		camara2.GetComponent<AudioListener> ().enabled = false;

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			camara1.enabled = true;
			camara1.GetComponent<AudioListener> ().enabled = true;
			camara2.enabled = false;
			camara2.GetComponent<AudioListener> ().enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			camara1.enabled = false;
			camara1.GetComponent<AudioListener> ().enabled = false;
			camara2.enabled = true;
			camara2.GetComponent<AudioListener> ().enabled = true;
		}
	}
}
