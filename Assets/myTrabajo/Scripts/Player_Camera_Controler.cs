using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera_Controler : MonoBehaviour {


		public class PlayerCameraController : MonoBehaviour
		{
			public float HorizontalSensitivity = 3.5f;
			public float VerticalSensitivity = 3.5f;
			public int VerticalInversion = -1;

			private float xRotation = 0.0f;
			private float yRotation = 0.0f;

			public void Start()
			{
				Cursor.lockState = CursorLockMode.Locked;
			}

			public void FixedUpdate()
			{
				this.xRotation += this.VerticalInversion * this.VerticalSensitivity * Input.GetAxis("Mouse Y");
				this.yRotation += this.HorizontalSensitivity * Input.GetAxis("Mouse X");

				this.transform.eulerAngles = new Vector3(this.xRotation, this.yRotation, 0);
			}
		}
	}

