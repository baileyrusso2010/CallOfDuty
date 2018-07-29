using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomahawk : MonoBehaviour {

	//how fast to thow it
	public int throwingSpeed = 0;

	//reference to player
	GameObject player;

	private bool timesUp = false;

	//countdown timers
	private float fireRate = 1f;
	private float fireCountdown = 0;

	//list to zombies
	List<Zombie> zombieList;

	//number of zombies hit
	int numOfZombiesHit = 0;

	//distance between objects
	Vector3 distance;

	Vector3 playerStartPos;

	//zombie holder
	Zombie zomb;

	//spawn it as a gameobject then delete it,
	//dont make it apart of the character


	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	// Use this for initialization
	void Start () 
	{
		timesUp = false;

		zombieList = new List<Zombie> ();
		zombieList = ZombieSpawner.zombieList;

		fireCountdown = 4f / fireRate;

		distance = -player.transform.forward;

		playerStartPos = player.transform.position;


	}
	
	// Update is called once per frame
	void Update () {


		if(zomb == null)
			zomb = GetZombie ();


		//if it doesn't return null
		if (zomb != null && timesUp == false) 
		{
			distance = DistanceToObject (zomb.transform.position);
		
			//if it's in a reasonable amount of distance within zombie
			if (distance.sqrMagnitude < .3f) 
			{
				numOfZombiesHit += 1;

				zomb = null;

				//gets a new zombie
				zomb = GetZombie ();

			}
		}//end of checking if zombie is null
		else
		{
			if (fireCountdown <= 0f) 
			{
				
				timesUp = true;
			}
//			zomb = GetZombie ();

		}

		if(DistanceToObject(playerStartPos).sqrMagnitude > 35 && zomb == null)
		{
			timesUp = true;
		}

		if (numOfZombiesHit >= 3 || timesUp == true) 
		{
			timesUp = true;
			distance = DistanceToObject (player.transform.position);

		}

		if (DistanceToObject (player.transform.position).sqrMagnitude < 2f &&  timesUp == true) 
		{
			DestroyGameObject ();
		}

		//will eventually time out
		fireCountdown -= Time.deltaTime;

			
		//moves tomahawk
		transform.Translate (distance.normalized * throwingSpeed * Time.deltaTime);


	}//end of update
		

	Zombie GetZombie()
	{
		foreach(Zombie zb in zombieList)
		{
			Zombie zombieHolder;
			Vector3 dist = zb.transform.position - this.transform.position;

			//if it's in range and hasn't been visited proceed
			if (dist.sqrMagnitude < 35 && zb.isVisited == false) 
			{
				//we have now visited that zombie
				zb.isVisited = true;

				//get the zombie
				zombieHolder = zb;

				//;
				distance = dist;

				//we got em
				return zombieHolder;
			}

		}//end of foreach

		//cant find a zombie
		return null;

	}//end of getZombie


	void DestroyGameObject()
	{
		foreach(Zombie zb in zombieList)
		{
			zb.isVisited = false;
		}//end of foreach
		Destroy(this.gameObject);

	}//end of clear data


	Vector3 DistanceToObject(Vector3 pos)
	{
		return pos - this.transform.position;


	}//end of distance to object
}