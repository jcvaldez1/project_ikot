using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawning : MonoBehaviour {
	
	private GameObject toBeSpawned;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnCircle", 0.000001f, 3.0f);//Spawn a circle every 3 seconds
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnCircle(){
		ObjectPoolingManager.Instance.GetCircle ();//Spawn circle from Object pooling manager
	}
}
