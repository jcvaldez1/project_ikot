﻿using System.Collections;
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

	public GameObject GetCircle(){
		int color = Random.Range (0, 4);//Pick a random color (or no circle)
		float angle = Random.Range (0,360);//Pick a random angle around the spawnRadius (degrees in a circle)
		float x = Mathf.Cos (angle)*spawnRadius;//Basically cylindrical coordinates (wooo Math 54!)
		float y = Mathf.Sin (angle)*spawnRadius;

		Vector3 spawnPos = new Vector3 (x, y, 0.0f);//Generate a random spawn position from values calculated above

		if (color == 0) {//Spawn Green Circle
			foreach (GameObject circle in Green) {//Check if there's a deactivated circle in the green list
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);//Set circle position to the random one
					circle.SetActive (true);//Reactivate circle
					return circle;
				}
			}
			//If no deactivated circle in list, make new one and add that to the list
			GameObject prefabInstance = Instantiate (prefabCircleGreen);
			prefabInstance.transform.SetParent (transform);
			Green.Add (prefabInstance);

			return prefabInstance;
		} else if (color == 1) {//Pretty much the same for the rest of the colors
			foreach (GameObject circle in Blue) {
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);
					circle.SetActive (true);
					return circle;
				}
			}

			GameObject prefabInstance = Instantiate (prefabCircleBlue,spawnPos,Quaternion.identity);
			prefabInstance.transform.SetParent (transform);
			Green.Add (prefabInstance);

			return prefabInstance;
		} else if (color == 2) {
			foreach (GameObject circle in Red) {
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);
					circle.SetActive (true);
					return circle;
				}
			}

			GameObject prefabInstance = Instantiate (prefabCircleRed,spawnPos,Quaternion.identity);
			prefabInstance.transform.SetParent (transform);
			Green.Add (prefabInstance);

			return prefabInstance;
		} else if (color == 3) {
			foreach (GameObject circle in Yellow) {
				if (!circle.activeInHierarchy) {
					circle.transform.SetPositionAndRotation (spawnPos, Quaternion.identity);
					circle.SetActive (true);
					return circle;
				}
			}

			GameObject prefabInstance = Instantiate (prefabCircleYellow,spawnPos,Quaternion.identity);
			prefabInstance.transform.SetParent (transform);
			Green.Add (prefabInstance);

			return prefabInstance;
		} else {//Don't return anything if color = 4
			return null;
		}
	}
}
