using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	public float radius = 12f;

	public Vector3 ToObstacle(Movement move)
	{
		//return distance between object
		return transform.position - move.transform.position;
	}

	public bool IsInFrontOf(Movement move)
	{
		Vector3 forward = move.heading;

		float dot = Vector3.Dot (forward,ToObstacle(move));

		return dot > 0;
	}

	public bool IsDangerousTo(Movement move)
	{
		Vector3 left = Helper.Perpendicularize (move.heading);

		float dot = Vector3.Dot (left, ToObstacle (move));

		bool onCollisionCourse = Mathf.Abs (dot) < radius+ 2f + .125f;
		bool isCloseEnough = dot < 5f;

		return onCollisionCourse && isCloseEnough;
	}
}