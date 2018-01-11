using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDisc : MonoBehaviour {

	public float speed;//Rotation speed
	private Vector2 startPos;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		speed = 150.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);//Register only one touch by the user

			switch (touch.phase) {
			case TouchPhase.Began:
				startPos = touch.position;//where you first touched the screen
				break;
			case TouchPhase.Moved://when the finger moves, rotate the circle accordingly
				direction = touch.position - startPos;//what direction you moved your finger
				startPos = touch.position;//update current position as start position for better control of the disc
				if (direction.y > 0 && startPos.x > Screen.width / 2) {//If you touched the right side of the screen and swiped up, rotate counter-clockwise
					transform.Rotate (0.0f, 0.0f, Time.deltaTime * speed);
				} else if (direction.y > 0 && startPos.x < Screen.width / 2) {//If you touched the left side of the screen and swiped up, rotate clockwise
					transform.Rotate (0.0f, 0.0f, -Time.deltaTime * speed);
				} else if (direction.y < 0 && startPos.x > Screen.width / 2) {//If you touched the right side of the screen and swiped down, rotate clockwise
					transform.Rotate (0.0f, 0.0f, -Time.deltaTime * speed);
				} else if (direction.y < 0 && startPos.x < Screen.width / 2) {//If you touched the left side of the screen and swiped down, rotate counter-clockwise
					transform.Rotate (0.0f, 0.0f, Time.deltaTime * speed);
				} else if (direction.x > 0 && startPos.x > Screen.height / 2) {//If you touched the upper side of the screen and swiped right, rotate clockwise
					transform.Rotate (0.0f, 0.0f, -Time.deltaTime * speed);
				} else if (direction.x > 0 && startPos.x < Screen.height / 2) {//If you touched the lower side of the screen and swiped right, rotate counter-clockwise
					transform.Rotate (0.0f, 0.0f, Time.deltaTime * speed);
				} else if (direction.x < 0 && startPos.x > Screen.height / 2) {//If you touched the upper side of the screen and swiped left, rotate counter-clockwise
					transform.Rotate (0.0f, 0.0f, Time.deltaTime * speed);
				} else if (direction.x < 0 && startPos.x < Screen.height / 2) {//If you touched the lower side of the screen and swiped left, rotate clockwise
					transform.Rotate (0.0f, 0.0f, -Time.deltaTime * speed);
				}
				break;
			case TouchPhase.Ended:
				break;
			}


		}
	}
}
