using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	
	private Transform ourDrone;

	void Awake()
	{
		ourDrone = GameObject.Find("DronParents").transform; 
	}

	private Vector3 velocityCameraFollow;
	public Vector3 behindPosition = new Vector3 (0, 2, -4);
	public float angle = 23.0f;

	void FixedUpdate() 
	{
		transform.position = Vector3.SmoothDamp (transform.position, ourDrone.transform.TransformPoint (behindPosition) + Vector3.up * Input.GetAxis ("Vertical"), ref velocityCameraFollow, 0.01f);
		transform.rotation = Quaternion.Euler(new Vector3(angle, ourDrone.GetComponent<DronMovementScript>().currentYRotation, 0f));  // eliminar copia en DronMovementScript si se cambia el script
	}


}
