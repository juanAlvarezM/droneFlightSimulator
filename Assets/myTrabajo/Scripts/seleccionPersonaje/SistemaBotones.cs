using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SistemaBotones : MonoBehaviour {

	public GameObject botonSiguiente;
	public GameObject botonAnterior;
	public GameObject Jugar;
	public GameObject player1;
	GameObject play1;
	public GameObject player2;
	GameObject play2;

	public void ActivarAnterior (){
		
		play2 = Instantiate (player2, new Vector3 (0.002f, 0.57450f, -8.652f), Quaternion.identity) as GameObject;
		Destroy (play1, 0);
		botonAnterior.SetActive (false);
		botonSiguiente.SetActive (true);
	}

	public void ActivarSiguiente(){
		
		play1 = Instantiate (player1, new Vector3 (-0.12f, 0.65f, -7.97f), Quaternion.identity) as GameObject;
		Destroy (play2, 0);
		botonAnterior.SetActive (true);
		botonSiguiente.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		
		botonSiguiente.SetActive (true);
		botonAnterior.SetActive (false);
		play2 = Instantiate (player2, new Vector3 (0.002f, 0.57450f, -8.652f), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
