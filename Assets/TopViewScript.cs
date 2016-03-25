using UnityEngine;
using System.Collections;

public class TopViewScript : MonoBehaviour {

	private Quaternion defaultRotation;
	private Vector3 defaultPosition;
	public float speedOfRotation;

	private Vector3 targetPosition;
	private float max = 20;
	private float accuX = 0;
	private float accuZ = 0;
	public GameObject targetGameObject;

	// Use this for initialization
	void Start () {
		defaultRotation = transform.localRotation;
		defaultPosition = transform.position;
		targetPosition = targetGameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		float moveZ = Input.GetKey (KeyCode.LeftArrow) ? -1 : Input.GetKey (KeyCode.RightArrow) ? 1 : 0;
		float moveX = Input.GetKey (KeyCode.UpArrow) ? -1 : Input.GetKey (KeyCode.DownArrow) ? 1 : 0;

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.position = defaultPosition;
			transform.localRotation = defaultRotation;
			accuX = accuZ = 0;
		}

		if (moveX + accuX < max && moveX + accuX > -max) {
			accuX += moveX;
		} else {
			moveX = 0;
		}

		if (moveZ + accuZ < max && moveZ + accuZ > -max) {
			accuZ += moveZ;
		} else {
			moveZ = 0;
		}

		transform.RotateAround (targetPosition, new Vector3(moveX, 0, moveZ), Time.deltaTime * speedOfRotation);

	}
}
