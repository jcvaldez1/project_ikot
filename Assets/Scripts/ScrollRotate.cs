using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRotate : MonoBehaviour {

	public GameObject constants;

	public float speed;//Rotation speed
	private Vector2 startPos;
	private Vector2 direction;
	private float rotatevalue = 500;

	public Text speedText;

	void Awake () {
		speed = 150f;
		speedText.text = "Speed/Sensitivity: " + speed;
	}

	bool counter = true;
	float previousrotatevalue = 500;

	public void move(float position){
		rotatevalue = position;
		counter = true;
	}

	void Update() {
		if(counter){
			transform.Rotate (0.0f, 0.0f, speed * Time.deltaTime * (21.5f*(rotatevalue - previousrotatevalue)));
			previousrotatevalue = rotatevalue;
		}
		counter = false;

	}

	public void changeSpeed(float newSpeed){
		if (newSpeed != speed) {
			speed = newSpeed;
			speedText.text = "Speed/Sensitivity: " + speed;
		}
	}
}
