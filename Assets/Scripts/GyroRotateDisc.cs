using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotateDisc : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 125f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, -Input.acceleration.x*Time.deltaTime*speed));
	}
}
