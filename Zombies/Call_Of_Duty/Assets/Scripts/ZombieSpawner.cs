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

    float spawnTime = 0, resetTime = 3f;

    int counter = 0;

	// Use this for initialization
	void Start () 
	{
        spawnTime = resetTime;

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

            spawnTime -= Time.deltaTime;

            if (spawnTime <= 0f)
            {
                SpawnZombie();
                counter++;
                spawnTime = resetTime;
            }

            if(counter > 5)
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
		

	}
}