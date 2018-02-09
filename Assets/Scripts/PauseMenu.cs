using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {





	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			this.enabled = !this.enabled;
		}
	}




}
