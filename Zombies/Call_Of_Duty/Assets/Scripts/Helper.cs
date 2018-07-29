using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {


	public static Vector3 Clamp(Vector3 original, float maxMagnitude)
	{
		if (original.sqrMagnitude > maxMagnitude * maxMagnitude) 
		{
			return original.normalized * maxMagnitude;
		}
		return original;
	}

	public static Vector3 Seek(Vector3 target, Vector3 position, Vector3 velocity)
	{
		Vector3 toTarget = target - position;

		Vector3 desiredVelocity = toTarget.normalized * 5;

		Vector3 steeringForce = desiredVelocity - velocity;

		return Helper.Clamp (steeringForce, 5f);
	}

	public static Vector3 Perpendicularize(Vector3 Input)
	{
		Vector3 left = Vector3.Cross (Input,Vector3.up);
		return left;
	}
}