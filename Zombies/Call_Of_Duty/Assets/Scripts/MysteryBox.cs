using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour {

	//list of gameObjects
	public GameObject[] weapons;

	public Player player;

	//countdown timers
	private float Rate = 1f;
	private float CountDown = 0;

	int weaponNum = 0;

	private bool stillChanging = false;

	void Start () 
	{
		
		//everything is set to false to start with
		for (int i = 0; i < weapons.Length; i++) {
			weapons [i] = (GameObject)Instantiate (weapons[i],transform.position,Quaternion.identity);
			weapons [i].SetActive (false);
			weapons [i].transform.parent = transform;
		}

	}
	
	
	void Update () 
	{
		for (int i = 0; i < weapons.Length; i++)
			weapons [i].transform.position = this.transform.position;

		if (stillChanging == false) {
			SwitchWeapons ();
			StartCoroutine (WeaponSelected ());
		} 

	}//end of update
		
	void SwitchWeapons()
	{
		CountDown += Time.deltaTime;

		if (CountDown > Rate) {
			CountDown = 0;

			weapons [weaponNum].SetActive (false);

			if (weaponNum >= weapons.Length - 1)
				weaponNum = 0;
			else
				weaponNum++;
		}//end of if

		weapons [weaponNum].SetActive (true);
	}

	IEnumerator WeaponSelected()
	{
		yield return new WaitForSeconds (8);
		stillChanging = true;
	}

}//end of script