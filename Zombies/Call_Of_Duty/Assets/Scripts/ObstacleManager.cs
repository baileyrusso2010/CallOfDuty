using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

	public static List<Obstacles> obstac = new List<Obstacles>();

	public List<Obstacles> holder = new List<Obstacles>();

	void Awake()
	{
		obstac = holder;
	}
}