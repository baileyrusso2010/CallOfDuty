using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement {

	public float jumpHeight;

	//[Header("Somethin")]
	Vector3 inputDirection;
	Vector3 rotationDirection;

	//access to camera if needed
	public Camera cam;

	//speed holders
	float speedHolder = 0;
	float fastSpeed;

	public Terrain ter;

	bool jumping = false;

	public int score = 0;

	// Use this for initialization
	void Start () {

		speedHolder = speed;

		fastSpeed = speed * 1.5f;

		//health 
		health = 100;

		//sets position 
		position = this.transform.position;

		//sets heading
		heading = Vector3.forward;


	}
		
	void Update()
	{


		if (this.transform.position.y > ter.transform.position.y && jumping == false) {
			transform.Translate (Vector3.down * 2 * Time.deltaTime);

			if (transform.position.y < .95) {
				Vector3 now = new Vector3 (transform.position.x,.95f,transform.position.z);
				this.transform.position = now;
				jumping = true;
			}

		}

		if (Input.GetKeyDown ("joystick button 1") && jumping == true) 	
		{
			
			transform.Translate (Vector3.up * 30 * Time.deltaTime);
			jumping = false;
		}
	}
}