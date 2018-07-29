using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

	public Transform playerBody;

	int zeroOut = 0;

	public float mouseSensitivity;

	float xAxisClamp = 0;


	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;

	}

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
	//	RotateCameraMouse ();
		RotateCameraController ();
	}

	void RotateCameraMouse()
	{
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");


		float rotAmountX = mouseX * mouseSensitivity;
		float rotAmountY = mouseY * mouseSensitivity;



		xAxisClamp += rotAmountY;

		Vector3 targetRotCam = transform.rotation.eulerAngles;
		Vector3 targetRotBody = playerBody.rotation.eulerAngles;


		targetRotCam.x -= rotAmountY;
		targetRotCam.z = 0;
		targetRotBody.y += rotAmountX;

		if (xAxisClamp > 70) {

			//this is up
			xAxisClamp = 70;
			targetRotCam.x = 290;

		} else if (xAxisClamp < -70) 
		{
			//this is down
			xAxisClamp = -70;
			targetRotCam.x = -290;
		}


		transform.rotation = Quaternion.Euler (targetRotCam);
		playerBody.rotation = Quaternion.Euler (targetRotBody);


	}


	void RotateCameraController()
	{
		//gets input from controller
		float mouseX = Input.GetAxis ("RightJoystickHorizontal");
		float mouseY = -Input.GetAxis ("RightJoystickVerticle");

		//gets a float to add to rotation
		float rotAmountX = mouseX * mouseSensitivity;
		float rotAmountY = mouseY * mouseSensitivity;

		//clamps the axis
		xAxisClamp += rotAmountY;

		//gets the rotation
		Vector3 targetRotCam = transform.rotation.eulerAngles;
		Vector3 targetRotBody = playerBody.rotation.eulerAngles;

		//adds the amount to the correct spot
		targetRotCam.x -= rotAmountY;
		targetRotCam.z = 0;
		targetRotBody.y += rotAmountX;

		targetRotBody.x = 0;

		//mathf doesn't work so
		//clamp it like this
		if (xAxisClamp > 70) {

			//this is up
			xAxisClamp = 70;
			targetRotCam.x = 290;

		} else if (xAxisClamp < -70) 
		{
			//this is down
			xAxisClamp = -70;
			targetRotCam.x = -290;
		}

		//makes it so it doesn't automatically move by itself
		if (Mathf.Abs(mouseX) > .3 || Mathf.Abs(mouseY) > .3) {
			transform.rotation = Quaternion.Euler (targetRotCam);
			playerBody.rotation = Quaternion.Euler (targetRotBody);
		}

	}

}
