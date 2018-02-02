﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawning : MonoBehaviour {
	public GameObject restart;

	private GameObject toBeSpawned;
	public bool gameOn;

	public int direction;
	public int pattern;
	// Use this for initialization

	void Start () {//On Enabled so it works when you pause it
		//InvokeRepeating ("spawnCircle", 3.0f, 3.0f);//Spawn a circle every 3 seconds, 
													//changed the initial timing here to 3 seconds so that unpausing doesn't cause weird pile ups
	}
	
	// Update is called once per frame
	void Update () {
		gameOn = restart.GetComponent<Restart> ().gameOn;//Only spawn circles when the game is ongoing
		if (GameObject.FindGameObjectWithTag ("BlueCircle") == null && GameObject.FindGameObjectWithTag ("GreenCircle") == null && GameObject.FindGameObjectWithTag ("RedCircle") == null && GameObject.FindGameObjectWithTag ("YellowCircle") == null && gameOn) {
			spawnCircle ();
		}
	}

	public void spawnCircle(){
		int regions = 4; // For now we only have 4 regions(quadrants) of the circle so the maximum number of circles spawned at the same time would be 4 
		int pair = Random.Range (1, regions); // for everytime spawnCircle is called, it will spawn pair number of circles
		int arclength = 360 / regions; // arclength would be the length of the regions in degrees (i have no idea if this is correct terminology wise)
		// initialize the start and ending positions of the circles in degrees
		int start_pos;
		int end_pos;
		int counter = 0;
		int RandomScaler = (Random.Range(0, regions)/1)*arclength;
		//RandomScaler = 0;

		//Determine revolve direction and pattern
		direction = determineDirection ();
		pattern = determinePattern ();

		// Generates a random list containing color mappings.
		List<int> alpha = new List<int> (regions);
		for (int j = 0; j < regions; j++) {
			alpha.Add (j);
		}
		for (int i = 0; i < alpha.Count; i++) {
			int temp = alpha[i];
			int randomIndex = Random.Range(i, alpha.Count);
			alpha[i] = alpha[randomIndex];
			alpha[randomIndex] = temp;
		}

		//  THIS FOR LOOP WOULD LOOP THROUGH ALL POSSIBLE COLORS AND WILL BREAK WHEN PAIR NUMBER OF COLORS ARE PICKED
		foreach (int color in alpha)
		{
			if (counter > pair) {
				break;
			}
			// since color numbers are mapped according to the region on the circle, the starting and end positions can be cimputed relatively
			start_pos = color * arclength + 40;
			end_pos = start_pos + arclength - 40;
			ObjectPoolingManager.Instance.GetCircle (color, start_pos + RandomScaler, end_pos + RandomScaler,direction);
			counter = counter + 1;
		}
	}

	public int determineDirection(){
		//Determines if circles revolve CW or CCW
		int revolveDirection = Random.Range (0, 2);

		if (revolveDirection == 0) {
			revolveDirection = 1;
		} else {
			revolveDirection = -1;
		}
			
		return revolveDirection;
	}

	public int determinePattern(){//tells the spawned circles what pattern to use
		//int pattern = Random.Range (0, 3);
		int pattern = 2;
		return pattern;
	}
}
