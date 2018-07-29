using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	//how fast to run
	public float speed;

	//how much health 
	public int health;

	public Vector3 heading;

	public float mass;

	[Header("Ablitily to move")]
	public Vector3 position, acceleration, velocity, steerForce;

		
}//end of script