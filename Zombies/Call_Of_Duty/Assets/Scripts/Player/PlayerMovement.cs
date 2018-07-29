using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	Vector3 inputDirection;

	public float speed;

	//speed holders
	float speedHolder = 0;
	float fastSpeed;

	// Use this for initialization
	void Start () {
		speedHolder = speed;

		fastSpeed = speed * 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();


	}


	void Move()
	{
		//movement input
		inputDirection.x = -Input.GetAxis ("LeftJoystickHorizontal");			
		inputDirection.z = Input.GetAxis ("LeftJoystickVerticle");


		//l3 allows to run
		if (Input.GetKey ("joystick button 10")) {
			speed = fastSpeed;
		} else
			speed = speedHolder;

		//so it doesn't keep moving 
		if (inputDirection.sqrMagnitude < 0.05)
			inputDirection = Vector3.zero;

		//will cancel out if any is zero
		transform.Translate (inputDirection * Time.deltaTime * speed);

	}
}
