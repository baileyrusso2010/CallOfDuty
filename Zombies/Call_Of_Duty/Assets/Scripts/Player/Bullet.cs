using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	private int speed = 80;

	private GameObject ob;

	Vector3 holder;

	float timeAmount = 0;

	GameObject[] zombies;


	void Start()
	{
		ob = GameObject.FindGameObjectWithTag ("barrel");
		holder = ob.transform.forward;
	}

	// Update is called once per frame
	void Update () 
	{
		zombies = GameObject.FindGameObjectsWithTag ("zombie");

		for(int i = 0; i < zombies.Length; i++)
		{
			if ((zombies[i].transform.position - this.transform.position).sqrMagnitude < .5) 
			{
				Destroy (zombies[i].gameObject);
				Destroy (this.gameObject);
			}
		}

		transform.Translate (holder.normalized * speed * Time.deltaTime);

		timeAmount += Time.deltaTime;

		if(timeAmount > 1.5f)
		{
			Destroy (this.gameObject);
		}
	}
}