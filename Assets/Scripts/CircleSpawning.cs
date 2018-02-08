using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawning : MonoBehaviour {

	public GameObject restart;
	private GameObject toBeSpawned;
	public bool gameOn;
	public int direction;
	public int pattern;
	private int TickThreshold = 0;
	public int NUMBER_OF_PATTERNS = 3;
	public float TICK_INTERVAL = 10.0f;
	public int NUMBER_OF_REGIONS = 4;


	void Start () {
		//InvokeRepeating("spawnCircle", 0.00001f, TICK_INTERVAL);
	}
	void Update () {
		gameOn = restart.GetComponent<Restart> ().gameOn;
		if (GameObject.FindGameObjectsWithTag ("Blue").Length == 1 && GameObject.FindGameObjectsWithTag ("Red").Length == 1 && GameObject.FindGameObjectsWithTag ("Yellow").Length == 1 && GameObject.FindGameObjectsWithTag ("Green").Length == 1) {
			spawnCircle ();
		}
	}




	public void spawnCircle(){
		if (gameOn) {
			//Debug.Log ("Troy!");
			int regions = NUMBER_OF_REGIONS;
			int pair = Random.Range (1, regions);
			int arclength = 360 / regions;
			int RandomScaler = (Random.Range (0, regions) / 1) * arclength;
			direction = (int)DetermineCircleDirection ();
			pattern = DetermineCirclePattern ();
			List<int> alpha = GetColorList (regions);
			int start_pos;
			int end_pos;
			int counter = 0;

			foreach (int color in alpha) {
				if (counter > pair) {
					break;
				}
				start_pos = color * arclength + 40;
				end_pos = start_pos + arclength - 40;
				ObjectPoolingManager.Instance.GetCircle (color, start_pos + RandomScaler, end_pos + RandomScaler, direction);
				counter = counter + 1;
			}
		}

	}



/*	private float TickInterval() {
		float TickValue = TICK_INTERVAL;
		return TickValue;
	}*/







	public float DetermineCircleDirection(){
		float revolveDirection = Mathf.Pow(-1,Random.Range (0, 2));
		return revolveDirection;
	}







	public int DetermineCirclePattern(){
		int pattern = Random.Range (0, NUMBER_OF_PATTERNS);
		return pattern;
	}






	public List<int> GetColorList (int regions){
		List<int> alpha = new List<int> (regions);
		for (int j = 0; j < regions; j++) {
			alpha.Add (j);
		}
		for (int i = 0; i < alpha.Count; i++) {
			int temp = alpha [i];
			int randomIndex = Random.Range (i, alpha.Count);
			alpha [i] = alpha [randomIndex];
			alpha [randomIndex] = temp;
		}
		return alpha;
	}






}
