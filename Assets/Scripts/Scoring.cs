﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public GameObject GreenDisc;
	public GameObject RedDisc;
	public GameObject BlueDisc;
	public GameObject YellowDisc;
	public Text scoreText;
	public Text bestscore;
	public int score;
	public static int highscore;


	void Start () {
		score = 0;
		SetHighScore ();
	}



	void Update () {
		scoreText.text = ""+score;
		CheckForHighScore ();
	}



	void CheckForHighScore() {
		if(score > highscore) {
			highscore = score;
			bestscore.text = "Highscore: " + highscore;
			PlayerPrefs.SetInt ("highscore", highscore);
		}
	}



	void SetHighScore() {
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
		bestscore.text = "Highscore: " + highscore.ToString();
	}

}