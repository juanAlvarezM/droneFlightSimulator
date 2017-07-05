using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Zoom_Camera : MonoBehaviour {
	
	public float StandardFOV = 62.5f;
	public float ReducedFOV = 32.5f;

	private bool isCameraZoomed = false;
	private int zoomButton = 1;
	private Camera playerCamera;

	public void Start()
	{
		this.playerCamera = GetComponent<Camera>();
	}

	public void Update()
	{
		if(Input.GetMouseButtonDown(this.zoomButton) && !this.isCameraZoomed)
		{
			this.playerCamera.fieldOfView = this.ReducedFOV;
			this.isCameraZoomed = true;
		}
		else if(Input.GetMouseButtonDown(this.zoomButton) && this.isCameraZoomed)
		{
			this.playerCamera.fieldOfView = this.StandardFOV;
			this.isCameraZoomed = false;
		}
	}
}

