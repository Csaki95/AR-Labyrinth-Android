using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script keeps the gameobject not destroyed in case you want same gameobject in different scene
public class DontDestroy : MonoBehaviour
{

	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		// If the same type of gameobject is present in scene already than it is destroyed useful when reloading the same scene
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
}