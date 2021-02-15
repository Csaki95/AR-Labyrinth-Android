using UnityEngine;

// Singleton: This script keeps the gameobject not destroyed in case you want same gameobject in different scene
public class DontDestroy : MonoBehaviour
{

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
		// If the same type of gameobject is present in scene already than it is destroyed
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}
}