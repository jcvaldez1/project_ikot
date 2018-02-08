using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroRotateDisc : MonoBehaviour {

	public GameObject constants;
	public GameObject speedSlider;
	public Text speedText;
	public float speed;




	void Awake () {
		speed = speedSlider.GetComponent<Slider>().value;
		speedText.text = "Speed/Sensitivity: " + speed;
	}
		





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
