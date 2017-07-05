using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement_Controller : MonoBehaviour {

		public float ForwardMovementSpeed = 0.25f;
		public float SideMovementSpeed = 0.1f;
		public float VerticalMovementSpeed = 0.125f;

		private Dictionary<string, KeyCode> movementKeyBindings = new Dictionary<string, KeyCode>()
		{
			{ "FORWARD", KeyCode.W },
			{ "BACKWARD", KeyCode.S },
			{ "LEFT", KeyCode.A },
			{ "RIGHT", KeyCode.D },
			{ "UP", KeyCode.Space },
			{ "DOWN", KeyCode.LeftShift }
		};

		public void FixedUpdate()
		{
			if(Input.GetKey(this.movementKeyBindings["FORWARD"]))
			{
				this.transform.position += new Vector3(
					this.transform.forward.x * this.ForwardMovementSpeed, 
					0, 
					this.transform.forward.z * this.ForwardMovementSpeed
				);
			}

			if(Input.GetKey(this.movementKeyBindings["BACKWARD"]))
			{
				this.transform.position += new Vector3(
					this.transform.forward.x * (-this.ForwardMovementSpeed / 1.95f),
					0,
					this.transform.forward.z * (-this.ForwardMovementSpeed / 1.95f)
				);
			}

			if(Input.GetKey(this.movementKeyBindings["LEFT"]))
			{
				this.transform.Translate(Vector3.left * this.SideMovementSpeed);
			}

			if(Input.GetKey(this.movementKeyBindings["RIGHT"]))
			{
				this.transform.Translate(Vector3.right * this.SideMovementSpeed);
			}

			if(Input.GetKey(this.movementKeyBindings["UP"]))
			{
				this.transform.Translate(Vector3.up * this.VerticalMovementSpeed);
			}

			if(Input.GetKey(this.movementKeyBindings["DOWN"]))
			{
				this.transform.Translate(Vector3.down * this.VerticalMovementSpeed);
			}
		}
	}
