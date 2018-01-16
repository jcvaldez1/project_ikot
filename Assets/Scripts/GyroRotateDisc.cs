﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroRotateDisc : MonoBehaviour {

	public GameObject constants;

	public Text speedText;

	public float speed;


	void Awake () {
		speed = 150f;
		speedText.text = "Speed/Sensitivity: " + speed;
	}

	// Use this for initialization
	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, -Input.acceleration.x*Time.deltaTime*speed));
	}

	public void changeSpeed(float newSpeed){
		if (newSpeed != speed) {
			speed = newSpeed;
			speedText.text = "Speed/Sensitivity: " + speed;
		}
	}
}
