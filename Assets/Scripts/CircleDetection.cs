using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleDetection : MonoBehaviour {

	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		//Basically, if the disc was a certain color, add a point if the disc makes contact with a circle of the same color
		//Deactivate the circles that come into contact for use later
		if (this.tag == "GreenDisc") {
			if (coll.tag == "GreenCircle") {
				score =  score + 1;
				coll.gameObject.SetActive (false);
			} else {
				coll.gameObject.SetActive (false);
			}
		} else if (this.tag == "RedDisc") {
			if (coll.tag == "RedCircle") {
				score =  score + 1;
				coll.gameObject.SetActive (false);
			} else {
				coll.gameObject.SetActive (false);
			}
		} else if (this.tag == "BlueDisc") {
			if (coll.tag == "BlueCircle") {
				score =  score + 1;
				coll.gameObject.SetActive (false);
			} else {
				coll.gameObject.SetActive (false);
			}
		} else if (this.tag == "YellowDisc") {
			if (coll.tag == "YellowCircle") {
				score =  score + 1;
				coll.gameObject.SetActive (false);
			} else {
				coll.gameObject.SetActive (false);
			}
		}
	}
}
