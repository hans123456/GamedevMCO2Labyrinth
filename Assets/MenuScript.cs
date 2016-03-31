using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public bool isVisible = true;
	public bool hasWon = false;
	private GameObject game;

	// Use this for initialization
	void Start () {
		game = GameObject.FindGameObjectWithTag ("Game");
		game.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		//GUI.Button (new Rect (0, 0, 200, 30), "Play Game");
		if (isVisible == false) {
			return;
		}

		if (hasWon == true) {
			if (GUI.Button (new Rect (Screen.width / 2 - 90, 100, 200, 30), "Play Again")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				game.SetActive (false);
			}
		} else if(hasWon == false) {
			if (GUI.Button (new Rect (Screen.width / 2 - 90, 100, 200, 30), "Play Game")) {
				isVisible = false;
				game.SetActive (true);
			}
		}

	}

}
