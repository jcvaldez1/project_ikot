using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour {

	private static ObjectPoolingManager instance;
	public static ObjectPoolingManager Instance { get { return instance; } }

	public GameObject prefabCircleGreen;
	public GameObject prefabCircleBlue;
	public GameObject prefabCircleRed;
	public GameObject prefabCircleYellow;

	public int spawnRadius;//How far away the circles would spawn
	public int eachAmount = 3;//How many circles to preload(for each color)

	private List<GameObject> Green;
	private List<GameObject> Blue;
	private List<GameObject> Red;
	private List<GameObject> Yellow;

	void Awake(){
		instance = this;
		spawnRadius = 8;

		//For each color, generate a list with the starting amount
		//Then, fill the lists with circles of the aprropriate color
		//Circles are deactivated until the GetCircle Function is called
		Green = new List<GameObject> (eachAmount);

		for (int i = 0; i < eachAmount; i++) {
			GameObject prefabInstance = Instantiate (prefabCircleGreen);
			prefabInstance.transform.SetParent (transform);
			prefabInstance.SetActive (false);

			Green.Add (prefabInstance);
		}

		Blue = new List<GameObject> (eachAmount);

		for (int i = 0; i < eachAmount; i++) {
			GameObject prefabInstance = Instantiate (prefabCircleBlue);
			prefabInstance.transform.SetParent (transform);
			prefabInstance.SetActive (false);

			Blue.Add (prefabInstance);
		}

		Red = new List<GameObject> (eachAmount);

		for (int i = 0; i < eachAmount; i++) {
			GameObject prefabInstance = Instantiate (prefabCircleRed);
			prefabInstance.transform.SetParent (transform);
			prefabInstance.SetActive (false);

			Red.Add (prefabInstance);
		}

		Yellow = new List<GameObject> (eachAmount);

		for (int i = 0; i < eachAmount; i++) {
			GameObject prefabInstance = Instantiate (prefabCircleYellow);
			prefabInstance.transform.SetParent (transform);
			prefabInstance.SetActive (false);

			Yellow.Add (prefabInstance);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject GetCircle(int color , int start_pos , int end_pos , int direction){ 
		// Added constants for clearer color mapping
		int GREEN = 0;
		int RED = 1;
		int YELLOW = 2;
		int BLUE = 3;
		// Added color as an external parameter so this method would be more flexibly manipulated from the outside.
		// Added start and end position as parameters instead of arbitrarily set values
		// NOTE THAT THE COLOR MAPPING HAS BEEN CHANGED ACCORDING TO QUADRANT PLACEMENT IN THE CIRCLE
		// HAVE REMOVED ABITRARY COLOR SETTER
		// HAVE REMOVED ARBITRARY POSITION SETTER
		float angle = Random.Range (start_pos , end_pos); // Picks a random point in the arc region defined by start and end_pos.

		// Added conversion of degree to radian for the Cos and Sin funcx
		float x = Mathf.Cos(angle*Mathf.Deg2Rad)*spawnRadius;//Basically cylindrical coordinates (wooo Math 54!)
		float y = Mathf.Sin(angle*Mathf.Deg2Rad)*spawnRadius;

		Vector3 spawnPos = new Vector3 (x, y, 0.0f);//Generate a random spawn position from values calculated above

		if (color == GREEN) {//Spawn Green Circle
			foreach (GameObject circle in Green) {//Check if there's a deactivated circle in the green list
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);//Set circle position to the random one
					circle.GetComponent<moveToCenter>().dir = direction;
					circle.SetActive (true);//Reactivate circle
					return circle;
				}
			}
			//If no deactivated circle in list, make new one and add that to the list
			GameObject prefabInstance = Instantiate (prefabCircleGreen);
			prefabInstance.GetComponent<moveToCenter>().dir = direction;
			prefabInstance.transform.SetParent (transform);
			Green.Add (prefabInstance);

			return prefabInstance;
		} else if (color == BLUE) {//Pretty much the same for the rest of the colors
			foreach (GameObject circle in Blue) {
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);
					circle.GetComponent<moveToCenter>().dir = direction;
					circle.SetActive (true);
					return circle;
				}
			}

			GameObject prefabInstance = Instantiate (prefabCircleBlue);
			prefabInstance.GetComponent<moveToCenter>().dir = direction;
			prefabInstance.transform.SetParent (transform);
			Blue.Add (prefabInstance);

			return prefabInstance;
		} else if (color == RED) {
			foreach (GameObject circle in Red) {
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);
					circle.GetComponent<moveToCenter>().dir = direction;
					circle.SetActive (true);
					return circle;
				}
			}

			GameObject prefabInstance = Instantiate (prefabCircleRed);
			prefabInstance.GetComponent<moveToCenter>().dir = direction;
			prefabInstance.transform.SetParent (transform);
			Red.Add (prefabInstance);

			return prefabInstance;
		} else if (color == YELLOW) {
			foreach (GameObject circle in Yellow) {
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);
					circle.GetComponent<moveToCenter>().dir = direction;
					circle.SetActive (true);
					return circle;
				}
			}

			GameObject prefabInstance = Instantiate (prefabCircleYellow);
			prefabInstance.GetComponent<moveToCenter>().dir = direction;
			prefabInstance.transform.SetParent (transform);
			Yellow.Add (prefabInstance);

			return prefabInstance;
		} else {//Don't return anything if color = 4
			return null;
		}
	}
}
