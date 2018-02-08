﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

	public GameObject objectPoolingManager;
	public GameObject gameController;
	public GameObject disc;
	public GameObject pause;
	public GameObject tryAgain;

	public bool gameOn = true;//Determines whether the game is ongoing or not

	public void lose(){
		gameOn = false;
		destroyCircles ();
		disc.SetActive (false);
		pause.SetActive (false);
		tryAgain.SetActive (true);
	}


	public void reset(){
		gameOn = true;
		objectPoolingManager.GetComponent<ObjectPoolingManager> ().createCircles ();
		disc.SetActive (true);
		pause.SetActive (true);
		tryAgain.SetActive (false);
		GameObject.FindGameObjectWithTag("GameController").GetComponent<Scoring>().score = 0;
	}

	public void restart(){
		gameOn = false;
		destroyCircles ();
		gameOn = true;
		objectPoolingManager.GetComponent<ObjectPoolingManager> ().createCircles ();
		GameObject.FindGameObjectWithTag("GameController").GetComponent<Scoring>().score = 0;
	}

	public void destroyCircles(){
		foreach (Transform circle in objectPoolingManager.transform) {//Destroys children(the circles) of ObjectPoolingManager
			Destroy (circle.gameObject);
		}
	}
}
