using UnityEngine;
using System.Collections;

public class TopViewScript : MonoBehaviour {

	public float speedOfRotation;
	public GameObject targetGameObject;
	public MenuScript menu;
	private Vector3 targetPosition;
	private Quaternion defaultRotation;
	private Vector3 defaultPosition;

	private float max = 10;
	private float accuX = 0;
	private float accuZ = 0;

	// Use this for initialization
	void Start () {
		defaultRotation = transform.localRotation;
		defaultPosition = transform.position;
		targetPosition = targetGameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (menu.isVisible == true) {
			return;
		}

		float moveZ = Input.GetKey (KeyCode.LeftArrow) ? -1 : Input.GetKey (KeyCode.RightArrow) ? 1 : 0;
		float moveX = Input.GetKey (KeyCode.UpArrow) ? -1 : Input.GetKey (KeyCode.DownArrow) ? 1 : 0;

		if (Input.GetKeyDown (KeyCode.Space)) {
			transform.position = defaultPosition;
			transform.localRotation = defaultRotation;
			accuX = accuZ = 0;
		}

		if (moveX + accuX < defaultRotation.x + max && moveX + accuX > defaultRotation.x - max) {
			accuX += moveX;
		} else {
			moveX = 0;
		}

		if (moveZ + accuZ < defaultRotation.z + max && moveZ + accuZ > defaultRotation.z - max) {
			accuZ += moveZ;
		} else {
			moveZ = 0;
		}

		transform.RotateAround (targetPosition, new Vector3(moveX, 0, moveZ), Time.deltaTime * speedOfRotation);

	}
}
