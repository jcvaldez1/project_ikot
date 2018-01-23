using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToCenter : MonoBehaviour {
	public float speed;
	public float radius;

	public int dir;

	public GameObject gameController;

	private Vector3 toCenter;
	private Vector3 toCircle;
	private int rotateDirection;

	void Awake(){
		speed = 0.25f;//Move speed
		radius = 4.0f;
	}

	// Use this for initialization
	void OnEnable () {
		
	}
	
	// Update is called once per frame
	void Update () {
		toCenter = new Vector3 (0.0f - transform.position.x, 0.0f - transform.position.y, 0.0f).normalized;//Vector pointing to center
		toCircle = Vector3.Cross(toCenter,new Vector3(transform.position.x,transform.position.y,1)).normalized;//Vector field forming a circle around the center

		transform.Translate (dir * toCircle * Time.deltaTime);//Rotate around the circle
		transform.Translate (toCenter * Time.deltaTime);//Follow the vector and move towards the center at a given speed per second
	}


}
