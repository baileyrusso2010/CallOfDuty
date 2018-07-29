using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justtesting : MonoBehaviour {



	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("sdfsdf");
		if (col.gameObject.name == "Sphere(Clone)") {
			Debug.Log ("sdf");
			Destroy (col.gameObject);

		}
	}
}
