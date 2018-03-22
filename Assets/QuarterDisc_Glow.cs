using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarterDisc_Glow : MonoBehaviour {
	private GameObject gameController;
	private GameObject resta;

	public GameObject GlowDisc;

	void Start(){
		GlowDisc.SetActive (false);
	}

	void Update () {
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		resta = GameObject.FindGameObjectWithTag ("Restart");
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (object.Equals (this.tag, coll.tag)) {
			print ("Glow!");
			//Invoke("GlowOn", 2);
			//this.gameObject.SetActive (false);
			StartCoroutine (WaitGlow ());
			//this.gameObject.SetActive (true);
		} else {
			resta.GetComponent<Restart>().lose();
		}
	}

	void GlowOn()
	{
		GameObject Glow = Instantiate(GlowDisc);
	}

	IEnumerator WaitGlow(){
		GlowDisc.SetActive (true);
		print (Time.time);
		yield return new WaitForSeconds (2);
		print (Time.time);
		GlowDisc.SetActive (false);
	}
}