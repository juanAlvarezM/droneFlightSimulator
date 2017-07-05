using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TwoButtons : MonoBehaviour {

	public float speed;
	private float amoutToMove;

	SerialPort sp = new SerialPort ("COM6", 9600);

	void Start () {
		sp.Open ();
		sp.ReadTimeout = 1; 
	}
	

	void Update () {
		amoutToMove = speed * Time.deltaTime;

		if(sp.IsOpen)
		{
			try
			{
				moveObject(sp.ReadByte());
				print(sp.ReadByte());
			}
			catch(System.Exception)
			{
				
			}
		}
	}

	void moveObject (int Direction)
	{
		if (Direction == 1) {
			transform.Translate (Vector3.left * amoutToMove, Space.World);
		}

		if (Direction == 2) {
			transform.Translate (Vector3.right * amoutToMove, Space.World);		
		}
	}
}
