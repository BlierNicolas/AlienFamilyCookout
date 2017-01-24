using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu_Script : MonoBehaviour {

	public int option = -1;
	public static int mode = 0;
	public static int player = 2;
	public static bool powup = true;
	public static bool lfs = false;
	public static int timer = -1;

	//Évite de garder en boucle l'affichage des panels
	public bool waiter = false;

	public Button btnGameMode, btnPowerUps, btnTimer, btnLFS;
	public Slider sld;
	public Sprite left_arrow, right_arrow;
	public Text txtRecap;

	public List<Text> options = new List<Text> ();
	public List<GameObject> menu = new List<GameObject> ();

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		StartCoroutine (DelayedStart ());
		mode = 0;
		player = 2;
		addOption ();
		gtfo ();
	}

	IEnumerator DelayedStart()
	{
		yield return new WaitForEndOfFrame ();
		UI_Manager.ToggleUIMenu (true);
		UI_Manager.ToggleUIInGame (false);
		UI_Manager.ToggleUIMenuPause (false);
	}
	// Update is called once per frame
	void Update () {
		if (waiter) {
			switch (option) {
			case -1:
				break;
			case 0:
				showTitle ();
				break;
			case 1:
				showMode ();
				break;
			case 2:
				showPlayer ();
				break;
			case 3:
				showPowerUps ();
				break;
			case 4:
				showLFS ();
				break;
			case 5:
				showTimer ();
				break;
			case 6:
				showControls ();
				break;
			case 7:
				showWarning ();
				break;
			case 8:
				showCredits ();
				break;
			case 9:
				showStart ();
				break;
			}
		}

		if (Input.GetKeyDown ("a")) {
			if (option == 1) {
				changeGameMode ();
			} else if (option == 2) {
				if (sld.value != 2) {
					sld.value--;
				}
				changerPlayers ();
			} else if (option == 3) {
				changePowerUps ();
			} else if (option == 4) {
				changeLFS ();
			} else if (option == 5) {
				changeTimer ();
			}
		}
		if (Input.GetKeyDown ("d")) {
			if (option == 1) {
				changeGameMode ();
			} else if (option == 2) {
				if (sld.value != 4) {
					sld.value++;
				}
				changerPlayers ();
			} else if (option == 3) {
				changePowerUps ();
			} else if (option == 4) {
				changeLFS ();
			} else if (option == 5) {
				changeTimer ();
			}
		}

		if (Input.GetKeyDown ("k")) {
			if (option == 9) {
				initPartie ();
			} else {
				addOption ();
			}
		}
		if (Input.GetKeyDown ("l")) {
			if (option == 0) {
				option = 8;
				optionsBase ();
				addOption ();
				starter ();
			} else {
				subOption ();
			}
		}
	}

	public static int getPlayers() {
		return player;
	}

	public void setOptions() {
		option = 8;
		addOption ();
	}

	public void optionsBase() {
		mode = 0;
		player = 2;
		powup = true;
		lfs = false;
	}

	public void addOption () {
		option++;
		//Debug.Log (option);
		gtfo ();
		waiter = true;
	}

	public void subOption() {
		option--;
		gtfo ();
		waiter = true;
	}

	public void showTitle() {
		menu [0].gameObject.SetActive (true);
		options [0].color = Color.blue;
		waiter = false;
	}

	public void showMode() {
		menu [1].gameObject.SetActive (true);
		options [1].color = Color.blue;
		waiter = false;
	}

	public void showPlayer() {
		menu [2].gameObject.SetActive (true);
		options [2].color = Color.blue;
		waiter = false;
	}

	public void showPowerUps() {
		menu [3].gameObject.SetActive (true);
		options [3].color = Color.blue;
		waiter = false;
	}

	public void showLFS() {
		menu [4].gameObject.SetActive (true);
		options [4].color = Color.blue;
		waiter = false;
	}

	public void showTimer() {
		menu [5].gameObject.SetActive (true);
		options [5].color = Color.blue;
		waiter = false;
	}

	public void showControls() {
		menu [6].gameObject.SetActive (true);
		options [6].color = Color.blue;
		waiter = false;
	}

	public void showWarning() {
		menu [7].gameObject.SetActive (true);
		options [7].color = Color.blue;
		waiter = false;
	}

	public void showCredits() {
		menu [8].gameObject.SetActive (true);
		options [8].color = Color.blue;
		waiter = false;
	}

	public void showStart() {
		starter ();
		menu [9].gameObject.SetActive (true);
		options [9].color = Color.blue;
		waiter = false;
	}

	public void gtfo() {
		for (int i = 0; i < menu.Count; i++) {
			menu [i].gameObject.SetActive (false);
			options [i].color = Color.black;
		}
	}

	public void changeGameMode() {
		if (mode == 1) {
			mode = 0;
			btnGameMode.image.sprite = left_arrow;
		} else if (mode == 0) {
			mode = 1;
			btnGameMode.image.sprite = right_arrow;
		}
	}

	public void changePowerUps() {
		if (!powup) {
			powup = true;
			btnPowerUps.image.sprite = left_arrow;
		} else if (powup){
			powup = false;
			btnPowerUps.image.sprite = right_arrow;
		}
	}

	public void changeLFS() {
		if (!lfs) {
			lfs = true;
			btnLFS.image.sprite = left_arrow;
		} else if (lfs){
			lfs = false;
			btnLFS.image.sprite = right_arrow;
		}
	}

	public void changeTimer() {
		if (timer == -1) {
			timer = 180;
			btnTimer.image.sprite = left_arrow;
		} else if (timer == 180){
			timer = -1;
			btnTimer.image.sprite = right_arrow;
		}
	}

	public void changerPlayers() {
		player = (int)sld.value;
	}

	public void starter() {
		if (mode == 0) {
			txtRecap.text = "Game Mode : FFA\n";
		} else {
			txtRecap.text = "Game Mode : Coop\n";
		}

		txtRecap.text += "Number of Players : " + player + "\n";
		if (powup) {
			txtRecap.text += "Power-Ups : On\n";
		} else {
			txtRecap.text += "Power-Ups : Off\n";
		}
		if (lfs) {
			txtRecap.text += "LFS : On\n";
		} else {
			txtRecap.text += "LFS : Off\n";
		}
		if (timer == 180) {
			txtRecap.text += "Timer : 180 sec\n";
		} else {
			txtRecap.text += "Timer : None\n";
		}
	}

	public void initPartie() {
		//Rendre l'autre UI_InGame visible
		UI_Manager.ToggleUIInGame(true);

		//Launch les codes de UI_InGame
		UI_Manager.player.GetComponent<UI_InGame_Script>().createGame(player);

		//Cacher ce UI
		UI_Manager.ToggleUIMenu(false);
	}
}
