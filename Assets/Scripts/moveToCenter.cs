﻿using System.Collections;
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
	}
	
	// Update is called once per frame
	void Update () {
		if (pattern == 0) {
			Circle ();
		} else if (pattern == 1) {
			Triangle ();
		}
		Debug.Log (pattern);
	}

	void Circle(){
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		toCircle = Vector3.Cross(toCenter,new Vector3(transform.position.x,transform.position.y,1)).normalized;//Vector field forming a circle around the center

		transform.Translate (speed * dir * toCircle * Time.deltaTime);//Rotate around the circle
		transform.Translate (speed * toCenter * Time.deltaTime);//Follow the vector and move towards the center at a given speed per second
	}

	void Triangle(){
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		currentTime = Time.time;
		if (currentTime - startTime < 4.0f) {
			if (Vector3.Distance (Vector3.zero, transform.position) > 4) {
				transform.Translate (speed * toCenter * Time.deltaTime);
			} else if (Vector3.Distance (Vector3.zero, transform.position) < 4) {
				toCircle = Vector3.Cross (toCenter, new Vector3 (transform.position.x, transform.position.y, 1)).normalized;//Vector field forming a circle around the center
				transform.Translate (speed*dir * toCircle * Time.deltaTime);
			}
			currentTime = Time.time;
		} else {
			transform.Translate (2.0f * speed * toCenter * Time.deltaTime);
		}
	}


}
