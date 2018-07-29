using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour {

	public static int level;

	// Use this for initialization
	void Awake () 
	{
		level = 1;	
	}

	public static int levelIncreaser()
	{
		return level++;
	}


}