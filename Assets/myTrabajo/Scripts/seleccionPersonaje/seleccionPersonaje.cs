using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seleccionPersonaje : MonoBehaviour {

	private GameObject[] characterList;
	private int index;

	private void start()
	{
		characterList = new GameObject[transform.childCount]; //personajes
		//recorre el array con los personajes
		for (int i = 0; i < transform.childCount; i++) 
		{
			characterList[i] = transform.GetChild(i).gameObject;
		}
		// desactivamos el render 
		foreach (GameObject go in characterList) {
			go.SetActive (false);
		}
		// activamos el render del primer objeto
		if (characterList[0]) {
			characterList[0].SetActive (true);
		}
	}

	/*public void ToggleLeft()
	{
		// desactivar el render del presente elemento 
		characterList[index].SetActive(false);

		index--; 
		if (index < 0) {
			index = characterList.Length - 1; 
		}

		// activar el render del nuevo modelo 
		characterList[index].SetActive(true);
	}*/
}
