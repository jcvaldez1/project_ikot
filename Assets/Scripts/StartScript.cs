using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject game;
	public GameObject startStuff;

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount>0||Input.GetKeyDown("space")) {
			startStuff.SetActive (false);
			game.SetActive (true);
		}
	}

	public void gameStart(){
		
	}
}
