using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronGun : MonoBehaviour {

	void Update()
	{
		ShootingBullets ();
	}

	public Transform gunTransform;
	public GameObject bulletPrefab;
	public float fireRate = 6;
	private float waitTillNextFire = 0.01f;

	public void ShootingBullets()
	{
		if(Input.GetKey(KeyCode.Q))
		{
			if (waitTillNextFire <= 0) 
			{
				Instantiate (bulletPrefab, gunTransform.position, gunTransform.rotation);
				waitTillNextFire = 1; 
			}
		}
		waitTillNextFire -= fireRate * Time.deltaTime; 

	}

	public void ShootingBulletsLeap()
	{
		
			if (waitTillNextFire <= 0) 
			{
				Instantiate (bulletPrefab, gunTransform.position, gunTransform.rotation);
				waitTillNextFire = 1; 
			}

		waitTillNextFire -= fireRate * Time.deltaTime; 

	}
}
