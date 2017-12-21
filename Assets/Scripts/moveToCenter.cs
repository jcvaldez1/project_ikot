using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToCenter : MonoBehaviour {
	public float speed;

	private Vector3 toCenter;

	void Awake(){
		speed = 0.1f;//Move speed
	}

	// Use this for initialization
	void OnEnable () {
		speed = 0.1f;
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f);//Vector pointing to center
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (toCenter * speed * Time.deltaTime);//Follow the vector and move towards the center at a given speed per second
	}
}
