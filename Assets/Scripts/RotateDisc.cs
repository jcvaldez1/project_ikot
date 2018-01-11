using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDisc : MonoBehaviour {

	public float speed;//Rotation speed
	private Vector3 fromVector;
	private Vector3 toVector;

	private Vector3 fromTouch;
	private Vector3 toTouch;

	private float fromAngle;
	private float toAngle;

	// Use this for initialization
	void Start () {
		speed = 40.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);//Register only one touch by the user

			Debug.DrawLine(transform.position, new Vector3(touch.position.x,touch.position.y,0.0f),Color.white);
			switch (touch.phase) {
				case TouchPhase.Began:
					{
					fromTouch = new Vector3 (touch.position.x, touch.position.y, 10.0f);
					Vector3 fromTouchPos = Camera.main.ScreenToWorldPoint (fromTouch);
					fromVector = fromTouchPos - transform.position;
					//Debug.Log (Mathf.Atan2 (fromVector.y, fromVector.x) * Mathf.Rad2Deg);
					break;
					}
				case TouchPhase.Moved://when the finger moves, rotate the circle accordingly
					{
					toTouch = new Vector3 (touch.position.x, touch.position.y, 10.0f);
					Vector3 toTouchPos = Camera.main.ScreenToWorldPoint (toTouch);
					toVector = toTouchPos - transform.position;


					fromAngle = Mathf.Atan2 (fromVector.y, fromVector.x) * Mathf.Rad2Deg;
					toAngle = Mathf.Atan2 (toVector.y, toVector.x) * Mathf.Rad2Deg;

					if (fromAngle < 0) {
						fromAngle = fromAngle + 360f;
					}

					if (fromAngle > 0 && toAngle < 0) {
						toAngle = toAngle + 360f;
					}

					Debug.Log (toAngle);

					fromTouch = new Vector3 (touch.position.x, touch.position.y, 0.0f);
					Vector3 fromTouchPos = Camera.main.ScreenToWorldPoint (fromTouch);
					fromVector = fromTouchPos - transform.position;

					//Quaternion q = Quaternion.AngleAxis (toAngle - fromAngle, Vector3.forward);
					//transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * speed);

					transform.Rotate (0, 0, (toAngle-fromAngle)* Time.deltaTime * speed);

					break;
					}
				case TouchPhase.Ended:
				{
					break;
				}
			}
		}
	}
}

/*				direction = touch.position - startPos;//what direction you moved your finger
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
				}*/
