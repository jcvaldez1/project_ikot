using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToCenter : MonoBehaviour {
	public float speed;
	public float radius;
	private float startTime;
	private float currentTime;

	public int dir;
	public int pattern;

	public GameObject gameController;

	private Vector3 toCenter;
	private Vector3 toCircle;

	private string jukeState;
	private Vector3 startPos;

	void Awake(){
		speed = 2.0f;//Move speed
		radius = 4.0f;
	}

	// Use this for initialization
	void Start(){
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		dir = gameController.GetComponent<CircleSpawning> ().direction;
		pattern = gameController.GetComponent<CircleSpawning>().pattern;
		startTime = Time.time;

	}

	void OnEnable () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		dir = gameController.GetComponent<CircleSpawning> ().direction;
		pattern = gameController.GetComponent<CircleSpawning>().pattern;
		startTime = Time.time;
		jukeState = "none";
	}

	// Update is called once per frame
	void Update () {
		if (pattern == 0) {
			Easiest ();
		} else if (pattern == 1) {
			Easy ();
		} else if (pattern == 2) {
			Medium ();
		} else if (pattern == 3) {
			Hard ();
		}
	}

	void Easiest(){//Circles move to center, appears from start
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		transform.Translate (speed * toCenter * Time.deltaTime);//Follow the vector and move towards the center at a given speed per second
	}

	void Easy(){//Move to center while rotating around the circle, appears after 10pts.
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		toCircle = Vector3.Cross(toCenter,new Vector3(transform.position.x,transform.position.y,1)).normalized;//Vector field forming a circle around the center

		transform.Translate (2.5f*speed * dir * toCircle * Time.deltaTime);//Rotate around the circle
		transform.Translate (speed * toCenter * Time.deltaTime);//Follow the vector and move towards the center at a given speed per second
	}

	void Medium(){//Circles move to center, rotate around then circle at a certain distance, then move quickly inwards, appears after 25pts.
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		currentTime = Time.time;
		if (currentTime - startTime < 4.0f) {
			if (Vector3.Distance (Vector3.zero, transform.position) > 4) {
				transform.Translate (speed * toCenter * Time.deltaTime);
			} else if (Vector3.Distance (Vector3.zero, transform.position) < 4) {
				toCircle = Vector3.Cross (toCenter, new Vector3 (transform.position.x, transform.position.y, 1)).normalized;//Vector field forming a circle around the center
				transform.Translate (2.5f * speed*dir * toCircle * Time.deltaTime);
			}
			currentTime = Time.time;
		} else {
			transform.Translate (2.0f * speed * toCenter * Time.deltaTime);
		}
	}


	void Hard(){//Circles move to center, move away, and then spin really fast towards the center, appears after 50 pts.
		currentTime = Time.time;
		//Debug.Log ("Star: " + jukeState);
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		toCircle = Vector3.Cross(toCenter,new Vector3(transform.position.x,transform.position.y,1)).normalized;//Vector field forming a circle around the center

		float clockMultiplier = 1;
		float suckMultiplier = 1;

		if (jukeState == "none") {//normal patterns
			if (Vector3.Distance (Vector3.zero, transform.position) < 3.2f) {
				jukeState = "ignition";
			}
		} else if (jukeState == "ignition") {//backs out a bit away from center
			clockMultiplier = 0;
			suckMultiplier = -1;
			if (Vector3.Distance (Vector3.zero, transform.position) > 4.0f) {
				jukeState = "boost";
				startPos = transform.position;
			}
		} else if (jukeState == "boost") {//fast juke at 180 degrees from where it started
			clockMultiplier = -5f;
			suckMultiplier = 0f;
			if (Vector3.Angle (transform.position, startPos) > 176f) {
				jukeState = "event_horizon";
			}
		} else if (jukeState == "event_horizon") {
			clockMultiplier = 0f;
			suckMultiplier = 2;
		}


		transform.Translate (speed *  dir * clockMultiplier * toCircle * Time.deltaTime);//Rotate around the circle
		transform.Translate (speed * suckMultiplier * toCenter * Time.deltaTime);//Follow the vector and move towards the center at a given speed per second
	}
}
