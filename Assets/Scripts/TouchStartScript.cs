using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStartScript : MonoBehaviour {

	public GameObject game;
	public GameObject startStuff;

	void Update () {
		if (Input.touchCount>0||Input.GetKeyDown("space")) {
			startStuff.SetActive (false);
			game.SetActive (true);
		}
	}
}
