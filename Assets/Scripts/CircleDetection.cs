using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleDetection : MonoBehaviour {

	public int score;

	void Start () {
		score = 0;
	}

	void OnTriggerEnter2D(Collider2D coll){


		if (object.Equals (this.tag, coll.tag)) {
			score =  score + 1;
		}
		coll.gameObject.SetActive (false);
		/*if (this.tag == "GreenDisc") {
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
		}*/
	}
}
