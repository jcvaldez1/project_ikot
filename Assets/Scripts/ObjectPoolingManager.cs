using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour {

	private static ObjectPoolingManager instance;
	public static ObjectPoolingManager Instance { get { return instance; } }
	public const int NUMBER_OF_COLORS = 4;

	// GLOBAL COLOR MAPPING START
	public const int GREEN = 0;
	public const int RED = 1;
	public const int YELLOW = 2;
	public const int BLUE = 3;
	//GLOBAL COLOR MAPPING END

	public int PRELOAD_AMOUNT = 3;//How many circles to preload(for each color)

	// lists that containg the circle GameObjects
	public List<GameObject> PrefabCircles;
	private List<List<GameObject>> TheColors;

	public int spawnRadius;//How far away the circles would spawn


	void Awake(){
		instance = this;
		spawnRadius = 8;
		createCircles();
	}

	public void createCircles(){
		//For each color, generate a list with the starting amount
		//Then, fill the lists with circles of the aprropriate color
		//Circles are deactivated until the GetCircle Function is called
		TheColors = new List<List<GameObject>> (NUMBER_OF_COLORS);
		for (int i = 0; i < NUMBER_OF_COLORS; i++) {

			TheColors.Add( new List<GameObject> (PRELOAD_AMOUNT));

			for (int j = 0; j < PRELOAD_AMOUNT; j++) {
				GameObject prefabInstance = Instantiate (PrefabCircles[i]);
				prefabInstance.transform.SetParent (transform);
				prefabInstance.SetActive (false);

				TheColors[i].Add (prefabInstance);
			}
		}

	}





	public GameObject GetCircle(int color , int start_pos , int end_pos , int direction){ 

		float angle = Random.Range (start_pos , end_pos);
		float x = Mathf.Cos(angle*Mathf.Deg2Rad)*spawnRadius;
		float y = Mathf.Sin(angle*Mathf.Deg2Rad)*spawnRadius;
		Vector3 spawnPos = new Vector3 (x, y, 0.0f);

		foreach (GameObject circle in TheColors[color]) {//Check if there's a deactivated circle in the green list
			if (!circle.activeInHierarchy) {
				circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);//Set circle position to the random one
				//circle.GetComponent<moveToCenter> ().dir = direction;
				circle.SetActive (true);//Reactivate circle
				return circle;
			}
		}

		// IF no such Gameobject of the specific color exists, create another
		GameObject prefabInstance = Instantiate (PrefabCircles[color]);
		//prefabInstance.GetComponent<moveToCenter>().dir = direction;
		prefabInstance.transform.SetParent (transform);
		TheColors [color].Add (prefabInstance);
		return prefabInstance;

	}





}