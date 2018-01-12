using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscDetection : MonoBehaviour {

	private GameObject gameController;

	// Use this for initialization
	void OnEnable () {
		//Find gameController prefab
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){


		//If color of this circle matches color of disc, score a point
		if (this.gameObject.CompareTag ("BlueCircle") && coll.CompareTag ("BlueDisc")) {
			gameController.GetComponent<Scoring> ().score += 1;
		} else if (this.gameObject.CompareTag ("GreenCircle") && coll.CompareTag ("GreenDisc")) {
			gameController.GetComponent<Scoring> ().score += 1;
		} else if (this.gameObject.CompareTag ("RedCircle") && coll.CompareTag ("RedDisc")) {
			gameController.GetComponent<Scoring> ().score += 1;
		} else if (this.gameObject.CompareTag ("YellowCircle") && coll.CompareTag ("YellowDisc")) {
			gameController.GetComponent<Scoring> ().score += 1;
		}

		//Deactivate this circle once it hits the disc
		this.gameObject.SetActive (false);
	}
}
