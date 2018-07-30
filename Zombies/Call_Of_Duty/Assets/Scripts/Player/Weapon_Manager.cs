using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Manager : MonoBehaviour {

	[Header("Weapons in use")]
	public GameObject firstWeapon;
	public GameObject secondWeapon;

	public enum State {first, second};

	State state;

	void Start () 
	{
		state = State.first;
		secondWeapon = null;
	}

	void Update () {

		if (Input.GetKeyDown ("joystick button 3")) 
		{
			if (state == State.first)
				state = State.second;
			else if (state == State.second)
				state = State.first;


			SwitchWeapon ();
		}

	}

	void SwitchWeapon()
	{
		if (state == State.first && secondWeapon != null) 
		{
			firstWeapon.SetActive (false);
			secondWeapon.SetActive (true);

		}
		else if (state == State.second && firstWeapon != null) 
		{
			firstWeapon.SetActive (true);
			secondWeapon.SetActive (false);
		
		}

	}//end of switch weapon
}