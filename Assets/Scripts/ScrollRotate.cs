using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRotate : MonoBehaviour {

	public GameObject constants;

	public float speed;
	private Vector2 startPos;
	private Vector2 direction;
	bool counter = true;
	private float CURRENT_ROTATE_VALUE = 500;
	private float PREVIOUS_ROTATE_VALUE = 500;

	public Text speedText;

	void Awake () {
		speed = 150f;
		speedText.text = "Speed/Sensitivity: " + speed;
	}


	public void move(float position){
		CURRENT_ROTATE_VALUE = position;
		counter = true;
	}

	void Update() {
		if(counter){
			transform.Rotate (0.0f, 0.0f, speed * Time.deltaTime * (21.5f*(CURRENT_ROTATE_VALUE- PREVIOUS_ROTATE_VALUE)));
			PREVIOUS_ROTATE_VALUE = CURRENT_ROTATE_VALUE;
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
