using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public float speed;
	public Rigidbody rigidBody;
	public MenuScript menu;

	private float horizontalSpeed = 0;
	private float verticalSpeed = 0;
	private float limit = 10;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		if (menu.isVisible == true) {
			return;
		}

		float moveHorizontal = Input.GetKey (KeyCode.LeftArrow) ? -1 : Input.GetKey (KeyCode.RightArrow) ? 1 : 0;
		float moveVertical = Input.GetKey (KeyCode.UpArrow) ? 1 : Input.GetKey (KeyCode.DownArrow) ? -1 : 0;

		if (horizontalSpeed + moveHorizontal > -limit && horizontalSpeed + moveHorizontal < limit) {
			horizontalSpeed += moveHorizontal;
		} 

		if (verticalSpeed + moveVertical > -limit && verticalSpeed + moveVertical < limit) {
			verticalSpeed += moveVertical;
		}

		Physics.gravity = new Vector3 (horizontalSpeed * speed * Time.deltaTime, -9.8f, verticalSpeed * speed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Physics.gravity = new Vector3 (0, -9.8f, 0);
			rigidBody.velocity = Vector3.zero;
			rigidBody.angularVelocity = Vector3.zero;
			verticalSpeed = 0;
			horizontalSpeed = 0;
		}

	}

}
