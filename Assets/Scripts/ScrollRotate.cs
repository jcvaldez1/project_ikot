using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRotate : MonoBehaviour {

	public float speed;//Rotation speed
	private Vector2 startPos;
	private Vector2 direction;
	private float rotatevalue = 500;
	void Start () {
		speed = 150.0f;	
	}
	bool counter = true;
	float previousrotatevalue = 500;
	public void move(float position){
		rotatevalue = position;
		counter = true;
	}

	void Update() {
		if(counter){
			transform.Rotate (0.0f, 0.0f, Time.deltaTime * (21.5f*(rotatevalue - previousrotatevalue)));
			previousrotatevalue = rotatevalue;
		}
		counter = false;

	}
}
