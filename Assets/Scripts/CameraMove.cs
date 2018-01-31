using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public GameObject gameController;

	public int currentScore;
	public int lastScore;

	public int speed = 1;

	private bool moved;

	void Awake(){
		moved = true;
	}

	// Use this for initialization
	void Start () {
		lastScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		currentScore = gameController.GetComponent<Scoring> ().score;
		if (currentScore - lastScore >= 10) {
			Debug.Log ("move!");
			moved = false;
			lastScore = gameController.GetComponent<Scoring> ().score;
		}
		move ();
	}

	void move(){
		if (!moved) {
			if (transform.position.x == 0) {
				transform.position = new Vector3(1.22f,0.0f,-10f);
				moved = true;
			} else {
				transform.position = new Vector3 (0.0f, 0.0f, -10f);
				moved = true;
			}
		} else {
			moved = true;
		}
	}
}
