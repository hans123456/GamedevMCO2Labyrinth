using UnityEngine;
using System.Collections;

public class TopViewScript : MonoBehaviour {

	private Quaternion defaultRotation;
	private Vector3 defaultPosition;
	public float speedOfRotation;

	private Vector3 targetPosition;
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
		}

		transform.RotateAround (targetPosition, new Vector3(moveX, 0, moveZ), Time.deltaTime * speedOfRotation);

	}
}
