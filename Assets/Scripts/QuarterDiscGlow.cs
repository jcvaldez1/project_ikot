using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterDiscGlow : MonoBehaviour {

	public GameObject glow_blue;
	public GameObject glow_red;
	public GameObject glow_green;
	public GameObject glow_yellow;
	private int glow_color;

	void Start () {
		glow_color = 0;
		glow_blue.SetActive (false);
		glow_red.SetActive (false);
		glow_green.SetActive (false);
		glow_yellow.SetActive (false);
	}
	void OnTriggerEnter2D(Collider2D coll){

		if (object.Equals (this.tag, coll.tag)) {
			if (this.tag == "Green") {
				glow_green.SetActive (true);
				glow_color = 1;
			}
			else if (this.tag == "Red") {
				glow_red.SetActive (true);
				glow_color = 2;
			}
			else if (this.tag == "Blue") {
				glow_blue.SetActive (true);
				glow_color = 3;
			}
			else if (this.tag == "Yellow") {
				glow_yellow.SetActive (true);
				glow_color = 4;
			}
			StartCoroutine (stopGlow ());
		}
	}

	IEnumerator stopGlow() {
		yield return new WaitForSeconds (.3f);
		if (glow_color == 1) {
			glow_green.SetActive (false);
		}
		if (glow_color == 2) {
			glow_red.SetActive (false);
		}
		if (glow_color == 3) {
			glow_blue.SetActive (false);
		}
		if (glow_color == 4) {
			glow_yellow.SetActive (false);
		}
	}
}
