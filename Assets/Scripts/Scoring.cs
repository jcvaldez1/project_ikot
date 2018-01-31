using System.Collections;
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
	private int greenScore;
	private int redScore;
	private int blueScore;
	private int yellowScore;

	public static int highscore;
	// Use this for initialization
	void Start () {
		score = 0; 
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
		bestscore.text = "Highscore: " + highscore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ""+score;
		if(score > highscore){
			highscore = score;
			bestscore.text = "Highscore: " + highscore;
			PlayerPrefs.SetInt ("highscore", highscore);
		}
	}
}

/*
 * Old scoring script
 * //Scores for each of the disc colors
		greenScore = GreenDisc.GetComponent<CircleDetection>().score;
		redScore = RedDisc.GetComponent<CircleDetection>().score;
		blueScore = BlueDisc.GetComponent<CircleDetection>().score;
		yellowScore = YellowDisc.GetComponent<CircleDetection>().score;

		//Update score every frame
		score = greenScore + redScore + blueScore + yellowScore;//Player score is total of the individual disc score
		*/
