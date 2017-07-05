using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronMovementScriptCopia : MonoBehaviour {

	Rigidbody ourDrone;
	public float upForce;
	public GameObject manoDerecha; 
	public GameObject controladorMano; 
	public GameObject controladorMano2; 
	public float arribaAbajoDistancia;
	public float rotacionLinealDerecha;
	public float rotacionLinealIzquierda;

	void Update ()
	{
		
		manoDerecha.GetComponent<Transform>();
		controladorMano.GetComponent<Transform> ();
		arribaAbajoDistancia = controladorMano.transform.position.y - manoDerecha.transform.position.y; 
		rotacionLinealDerecha = controladorMano.transform.rotation.y - manoDerecha.transform.rotation.y;
		rotacionLinealIzquierda = controladorMano2.transform.rotation.y- manoDerecha.transform.rotation.y;
		Debug.Log (rotacionLinealIzquierda);

	}


	void Awake()
	{
		ourDrone = GetComponent<Rigidbody> ();
		droneSound = gameObject.transform.FindChild ("droneSound").GetComponent<AudioSource> ();
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
			if (Input.GetKey (KeyCode.I) || Input.GetKey (KeyCode.K)|| arribaAbajoDistancia < -0.6f || arribaAbajoDistancia > -0.45f) 
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

		if((Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f))
		{
			upForce = 135;
		}

		if (Input.GetKey (KeyCode.I) || arribaAbajoDistancia < -0.6f ) 
		{
			upForce = 450;
			if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
			{
				upForce = 500; 
			}
		} 
		else if (Input.GetKey (KeyCode.K) || arribaAbajoDistancia > -0.45f)
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

	void movementForward ()
	{
		if (Input.GetAxis ("Vertical") != 0 || (arribaAbajoDistancia < -0.6f || arribaAbajoDistancia > -0.45f) ) 
		{
			ourDrone.AddRelativeForce (Vector3.forward * Input.GetAxis ("Vertical") * movementForwardSpeed);
			tiltAmountforward = Mathf.SmoothDamp (tiltAmountforward, 20 * Input.GetAxis ("Vertical"), ref titlVelocityForward, 0.1f);
		}
	}

	private float wantedYRotation;
	[HideInInspector] public float currentYRotation;
	private float rotateAmoutByKeys = 2.5f;
	private float rotationYVelocity;

	void Rotation()
	{

			
		if (Input.GetKey (KeyCode.J)|| rotacionLinealIzquierda < 0.1f  &&  rotacionLinealIzquierda > 0.04f)  {
				wantedYRotation -= rotateAmoutByKeys; 
			}
			if (Input.GetKey (KeyCode.L) || rotacionLinealDerecha > 0.4f) {
				wantedYRotation += rotateAmoutByKeys;
			}


		currentYRotation = Mathf.SmoothDamp (currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
	}

	private Vector3 velocityToSmoothDampToZero;

	void clampingSpeedValues ()
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


	public void arriba()
	{
		upForce = 450;
		ourDrone.AddRelativeForce (Vector3.up * upForce);
		movementUpDown ();
	}
	public void abajo ()
	{
		upForce = -200;
		ourDrone.AddRelativeForce (Vector3.up * upForce);
	}
}
