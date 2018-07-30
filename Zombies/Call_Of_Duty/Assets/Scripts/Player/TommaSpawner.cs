using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommaSpawner : MonoBehaviour {

	//what it is 
	public GameObject tomHawk;

	//reference to the class
	//private ZombieSpawner zSpawner;

	//where it shoots out from
	public Transform spawnPlacement;

	//referene to player
	GameObject player;

	//gameObject that spawns tomHawk
	GameObject spawnT;

	void Start()
	{

		player = GameObject.FindGameObjectWithTag ("Player");
		spawnPlacement.transform.rotation = player.transform.rotation;
	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown("joystick button 5") && spawnT == null) 
		{

		//spawns gameobject
		 spawnT = (GameObject)Instantiate (tomHawk, spawnPlacement.transform.position,
				Quaternion.identity);	
		}//end of if
	}
}