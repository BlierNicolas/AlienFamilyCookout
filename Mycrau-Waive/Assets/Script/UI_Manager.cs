using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

	public static GameObject UI_Menu, UI_MenuPause, UI_InGame;
	public static GameObject player;

	void Start () {
		DontDestroyOnLoad (this.gameObject);
		UI_Menu = GameObject.FindGameObjectWithTag ("UI_Menu");
		UI_MenuPause = GameObject.FindGameObjectWithTag ("UI_Pause");
		UI_InGame = GameObject.FindGameObjectWithTag ("UI_InGame");
		player = GameObject.FindGameObjectWithTag ("UI_Manager");
	}

	public static void ToggleUIMenu(bool val) {
		UI_Menu.SetActive (val);
	}

	public static void ToggleUIMenuPause(bool val) {
		UI_MenuPause.SetActive (val);
	}

	public static void ToggleUIInGame(bool val) {
		UI_InGame.SetActive (val);
	}
}
