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

	private bool hasMoved;

	// Use this for initialization
	void Start () {
		speed = 40.0f;
		hasMoved = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);//Register only one touch by the user

			Debug.DrawLine(transform.position, new Vector3(touch.position.x,touch.position.y,0.0f),Color.white);
			switch (touch.phase) {
				case TouchPhase.Began:
					{//Compute the vector where the touch started
					fromTouch = new Vector3 (touch.position.x, touch.position.y, 10.0f);
					Vector3 fromTouchPos = Camera.main.ScreenToWorldPoint (fromTouch);
					fromVector = fromTouchPos - transform.position;
					//Debug.Log (Mathf.Atan2 (fromVector.y, fromVector.x) * Mathf.Rad2Deg);
					break;
					}
				case TouchPhase.Moved://when the finger moves, rotate the circle accordingly
					{//Compute the vector where the touch ended
					toTouch = new Vector3 (touch.position.x, touch.position.y, 10.0f);
					Vector3 toTouchPos = Camera.main.ScreenToWorldPoint (toTouch);
					toVector = toTouchPos - transform.position;

					//Compute the angles of those vectors
					fromAngle = Mathf.Atan2 (fromVector.y, fromVector.x) * Mathf.Rad2Deg;
					toAngle = Mathf.Atan2 (toVector.y, toVector.x) * Mathf.Rad2Deg;

					//Convert the angles from 0-180 which Unity uses to 0-360
					if (fromAngle < 0) {
						fromAngle = fromAngle + 360f;
					}

					if (toAngle < 0) {
						toAngle = toAngle + 360f;
					}

					//Account for when the angles have the x-axis (0-axis) in-between (360 becomes 0, 0 becomes 360)
					if ((fromAngle > 350) && (toAngle < 90)) {
						toAngle = toAngle + 360f;
					}

					if ((fromAngle < 90) && (toAngle > 350)){
						toAngle = toAngle - 360f;
					}

					//Debug.Log ("From:" + fromAngle + " To: " + toAngle + "Has Moved: " + hasMoved);

					//Rotate disc given computations
					transform.Rotate (0, 0, (toAngle-fromAngle)* Time.deltaTime * speed);


					//Compute new from values to ensure rotation is smooth
					fromTouch = new Vector3 (touch.position.x, touch.position.y, 10.0f);
					Vector3 fromTouchPos = Camera.main.ScreenToWorldPoint (fromTouch);
					fromVector = fromTouchPos - transform.position;

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

/*				
 * 
 * 
 * Older version of the rotation code
 * direction = touch.position - startPos;//what direction you moved your finger
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
