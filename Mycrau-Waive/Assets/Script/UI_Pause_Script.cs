using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pause_Script : MonoBehaviour {

	public static bool actif = false;
	public int selectedOption = 0;

	public Image arrow1, arrow2;
	public List<Image> arrows = new List<Image> ();

	public static int MAX_OPTIONS = 2;

	// Use this for initialization
	void Start () {
		arrows.Add (arrow1);
		arrows.Add (arrow2);
		for (int i = 0; i < arrows.Count; i++) {
			arrows [i].gameObject.SetActive (false);
		}
		afficher ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("k")) {
			if (selectedOption == 0) {
				resumeGame ();
			}
			if (selectedOption == 1) {
				exitGame ();
			}
		}
		if (Input.GetKeyDown ("l")) {
			resumeGame ();
		}
		if (Input.GetKeyDown ("w")) {
			if (selectedOption > 0) {
				up ();
			}
		}
		if (Input.GetKeyDown ("s")) {
			if (selectedOption < 1) {
				down();
			}
		}
	}

	public void afficher() {
		arrows [0].gameObject.SetActive (false);
		arrows [1].gameObject.SetActive (false);

		arrows [selectedOption].gameObject.SetActive (true);
	}

	public void up() {
		selectedOption--;
		if (selectedOption < 0) {
			selectedOption = 0;
		}
		afficher ();
	}

	public void down() {
		selectedOption++;
		if (selectedOption > (MAX_OPTIONS-1)) {
			selectedOption = MAX_OPTIONS - 1;
		}
		afficher ();
	}

	public void resumeGame() {
		UI_Manager.ToggleUIInGame (true);
		UI_Manager.ToggleUIMenuPause (false);
		//On remet la partie en cours
	}

	public void exitGame() {
		Application.Quit ();
		UI_Manager.ToggleUIMenu (true);
		UI_Manager.ToggleUIMenuPause (false);
		//Quitte la partie et remet le menu
	}
}
