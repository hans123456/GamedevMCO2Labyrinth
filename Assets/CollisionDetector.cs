using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	public GameObject goal;
	public MenuScript menu;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {
		
		if (menu.isVisible == true) {
			return;
		}

		if (collision.gameObject.name == goal.name) {
			menu.hasWon = true;
			menu.isVisible = true;
		}

	}

}