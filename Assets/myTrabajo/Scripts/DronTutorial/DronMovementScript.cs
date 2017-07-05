using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronMovementScript : MonoBehaviour {

	Rigidbody ourDrone;
	public float upForce;

	public void Awake()
	{
		ourDrone = GetComponent<Rigidbody>();
		droneSound = gameObject.transform.FindChild ("drone_sound").GetComponent<AudioSource> ();
	}

	public void FixedUpdate()
	{
		movementUpDown ();
		movementForward ();
		Rotation ();
		clampingSpeedValues ();
		serwewe ();
		DroneSound (); //Para sonido


		ourDrone.AddRelativeForce (Vector3.up * upForce);
		ourDrone.rotation = Quaternion.Euler (
			new Vector3(tiltAmountforward, currentYRotation,tiltAmountSideways)
		);
	}

	public void movementUpDown()
	{
		if((Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f))
		{
			if (Input.GetKey (KeyCode.I) || Input.GetKey (KeyCode.K)) 
			{
				ourDrone.velocity = ourDrone.velocity;
			}
			if (!Input.GetKey (KeyCode.I) && !Input.GetKey (KeyCode.K) && !Input.GetKey (KeyCode.J) && !Input.GetKey (KeyCode.L)) 
			{
				ourDrone.velocity = new Vector3 (ourDrone.velocity.x, Mathf.Lerp (ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
				upForce = 281; 
			}
			if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L)))
				{
				ourDrone.velocity = new Vector3 (ourDrone.velocity.x, Mathf.Lerp (ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
				upForce = 110;
				}
			if(Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
			{
				upForce = 410;
			}
		}

		if(Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
		{
			upForce = 135;
		}

		if (Input.GetKey (KeyCode.I)) 
		{
			upForce = 450;
			if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
			{
				upForce = 500; 
			}
		} 
		else if (Input.GetKey (KeyCode.K))
		{
			upForce = -200;
		}
		else if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f))
		{
			upForce = 98.1f;
		}
	}

	private float movementForwardSpeed = 500.0f; 
	private float tiltAmountforward = 0; 
	private float titlVelocityForward;

	public void movementForward ()
	{
		if (Input.GetAxis ("Vertical") != 0) 
		{
			ourDrone.AddRelativeForce (Vector3.forward * Input.GetAxis ("Vertical") * movementForwardSpeed);
			tiltAmountforward = Mathf.SmoothDamp (tiltAmountforward, 20 * Input.GetAxis ("Vertical"), ref titlVelocityForward, 0.1f);
		}
	}

	private float wantedYRotation;
	[HideInInspector] public float currentYRotation;
	private float rotateAmoutByKeys = 2.5f;
	private float rotationYVelocity;

	public void Rotation()
	{
		if (Input.GetKey (KeyCode.J))
		{
			wantedYRotation -= rotateAmoutByKeys; 
		}
		if (Input.GetKey (KeyCode.L)) 
		{
			wantedYRotation += rotateAmoutByKeys;
		}

		currentYRotation = Mathf.SmoothDamp (currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
	}

	private Vector3 velocityToSmoothDampToZero;

	public void clampingSpeedValues ()
	{
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) 
		{
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.2f) 
		{
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) 
		{
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal")) < 0.2f) 
		{
			ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
		}
	}

	private float sideMovementAmount = 300.0f;
	private float tiltAmountSideways;
	private float tiltAmountVelocity;

	void serwewe()
	{
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) {
			ourDrone.AddRelativeForce (Vector3.right * Input.GetAxis ("Horizontal") * sideMovementAmount);
			tiltAmountSideways = Mathf.SmoothDamp (tiltAmountSideways, -20 * Input.GetAxis ("Horizontal"), ref tiltAmountVelocity, 0.1f);
		} else {
			tiltAmountSideways = Mathf.SmoothDamp (tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
		}
	}

	private AudioSource droneSound; //sonido

	void DroneSound() 
	{
		droneSound.pitch = 1 + (ourDrone.velocity.magnitude / 100);
	}
}
