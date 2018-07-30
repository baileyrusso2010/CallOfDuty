using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

	public GameObject zombieModel;

	//list of zombies
	public static List<Zombie> zombieList;

	public Transform[] positionsToSpawn;

	//number of zombies to spawn
	private int numZombiesSpawn = 3;

	private bool roundOver = true;


	// Use this for initialization
	void Start () 
	{

		//instantiates list
		zombieList = new List<Zombie> ();
	
		//default number of zombies to spawn
		numZombiesSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (zombieList.Count == 0)
			roundOver = true;

		//if the round is over
		if(roundOver == true)
		{
			StartCoroutine (zombieSpawn());
			roundOver = false;
		}

	}

	void SpawnZombie()
	{
		//number holder
		int randomN = 0;

		//gets random location
		randomN = Random.Range (0, positionsToSpawn.Length);

		//spawns the zombie
		GameObject zombieSpawned = Instantiate (zombieModel, positionsToSpawn[randomN].transform.position, Quaternion.identity);
		//zombieList.Add (zombieSpawned);

	}

	IEnumerator zombieSpawn()
	{
		yield return new WaitForSeconds (2);

		//numZombiesSpawn *= Level_Manager.level;
		for(int i = 0; i < 3;i++)
		{
			SpawnZombie ();
		} 

	}

}