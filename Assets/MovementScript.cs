using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float speed;
	public Rigidbody rigidBody;
	private float horizontalSpeed = 0;
	private float verticalSpeed = 0;
	private float limit = 30;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetKey (KeyCode.LeftArrow) ? -1 : Input.GetKey (KeyCode.RightArrow) ? 1 : 0;
		float moveVertical = Input.GetKey (KeyCode.UpArrow) ? 1 : Input.GetKey (KeyCode.DownArrow) ? -1 : 0;

		if (horizontalSpeed + moveHorizontal > -limit && horizontalSpeed + moveHorizontal < limit) {
			horizontalSpeed += moveHorizontal;
		} 

		if (verticalSpeed + moveVertical > -limit && verticalSpeed + moveVertical < limit) {
			verticalSpeed += moveVertical;
		}

		Physics.gravity = new Vector3 (horizontalSpeed * Time.deltaTime * speed, -9.8f, verticalSpeed * Time.deltaTime * speed);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Physics.gravity = new Vector3 (0, -9.8f, 0);
			rigidBody.velocity = Vector3.zero;
			rigidBody.angularVelocity = Vector3.zero;
			verticalSpeed = 0;
			horizontalSpeed = 0;
		}

	}

}
