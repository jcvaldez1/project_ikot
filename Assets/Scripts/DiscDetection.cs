using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscDetection : MonoBehaviour {
	private GameObject gameController;
	private GameObject resta;

	void Update () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		resta = GameObject.FindGameObjectWithTag ("Restart");
	}




	void OnTriggerEnter2D(Collider2D coll){


		if (object.Equals (this.tag, coll.tag)) {
			gameController.GetComponent<Scoring> ().points += 1;
		} else {
			resta.GetComponent<Restart>().lose();
		}

		this.gameObject.SetActive (false);
	}



}
