using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


	public int ammo = 0;
	public int ammoPerCap = 0;

	private int maxAmmo = 0;
	private int maxAmmoPerCap = 0;

	bool reloading = false;

	public GameObject barrel;

	public GameObject bullet;


	// Use this for initialization
	void Start () 
	{

		maxAmmo = 30;
		maxAmmoPerCap = 60;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (reloading)
			return;

		if (Input.GetKeyDown ("joystick button 0")) 
		{
			StartCoroutine(Reload ());
			return;
		}

		if (Input.GetKeyDown ("joystick button 7") && ammo > 0) 
		{
			Shoot ();
		}
		
	}

	IEnumerator Reload()
	{
		//checks if you can reload
		if (ammo < maxAmmo && ammoPerCap > 0) 
		{
			reloading = true;
			yield return new WaitForSeconds (2);

			//amount of ammo needed
			int amount = maxAmmo - ammo;

			//if your able to take the ammo
			int amountNeeded = ammoPerCap - amount;

			if (amountNeeded >= 0) 
			{
				ammo += amount;
				ammoPerCap -= amount;
			}
			else  {
				ammo += ammoPerCap;
				ammoPerCap = 0;
			} 
				
		}//end of first if

		reloading = false;
	}//end of reload

	void Shoot()
	{

	    Instantiate (bullet, barrel.transform.position ,Quaternion.identity);
		ammo--;
	}

}