using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Movement {

	protected List<Obstacles> thisList;

	public GameObject target;

	public bool isVisited = false;

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player");

		heading = Vector3.forward;

		position = transform.position;
		acceleration = Vector3.zero;
		velocity = Vector3.zero;

		thisList = ObstacleManager.obstac;

		health = 100;

		ZombieSpawner.zombieList.Add (this);

	}
	
	// Update is called once per frame
	void Update () {
		CalcSteering ();
		target = GameObject.FindGameObjectWithTag ("Player");

	}


	private void ApplyForce(Vector3 force)
	{
		acceleration += force / mass;
	}     

	private void CalcSteering()
	{
		acceleration = Vector3.zero;

		steerForce = Vector3.zero;

		Vector3 avoidForce = AvoidObstacles ();

		Vector3 pos = Helper.Seek (target.transform.position,position,velocity);

		if (avoidForce == Vector3.zero) {
			steerForce += pos;
			LookTowardsObject ();
		}
		else
			steerForce += avoidForce;


		ApplyForce (steerForce);

		velocity += acceleration;

		velocity = Helper.Clamp (velocity,speed);

		position += velocity * Time.deltaTime;

		heading = velocity.normalized;

		transform.position = position;

	} 

	Vector3 FuturePosition(float seconds)
	{
		return transform.position + velocity * seconds;
	}

	private Vector3 AvoidObstacles()
	{
		Obstacles closest = null;
		float minDist = float.MaxValue;

		foreach(Obstacles ob in thisList)
		{
			if (ob.IsInFrontOf (this)) 
			{
				float dist = ob.ToObstacle (this).sqrMagnitude;
				if (dist < minDist) 
				{
					minDist = dist;
					closest = ob;
				}

			}
		}
		if (closest != null && closest.IsDangerousTo (this)) 
		{
			Vector3 left = Helper.Perpendicularize (heading);
			float dot = Vector3.Dot (left, closest.ToObstacle(this));
			float direction = dot < 0 ? 1 : -1;

			Vector3 forceTurn = left * 5f * direction;
			Vector3 forceBreak = this.velocity * -1.5f;

			return forceTurn + forceBreak;
			//return force turn + forceBreak
		}
		return Vector3.zero;

	}

	private void LookTowardsObject()
	{
		Vector3 direction = target.transform.position - this.transform.position;

		Quaternion rotation = Quaternion.LookRotation (direction);

		transform.rotation = Quaternion.RotateTowards (transform.rotation,rotation, 55f * Time.deltaTime);
	}
}