using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public Text scoreText;
	public Text bestscore;
	public int score;
	public int points;
	public static int highscore;

	public AudioClip scoreAudio;


	void Start () {
		score = 0;
		SetHighScore ();
	}



	void Update () {
		if (points != 0){
			AudioSource.PlayClipAtPoint (scoreAudio, Vector3.zero);
			score = score + points;
			points = 0;
		}
		scoreText.text = ""+ score;
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