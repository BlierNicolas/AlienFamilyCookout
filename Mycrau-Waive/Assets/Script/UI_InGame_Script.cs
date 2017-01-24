using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame_Script : MonoBehaviour {

	public static bool actif = false;
	int nbrPlayer;
	public List<GameObject> players = new List<GameObject> ();
	public List<Family> families = new List<Family> ();

	public List<GameObject> panels = new List<GameObject> ();
	public List<List<Image>> imgKids = new List<List<Image>> ();
	public List<Image> imgKids1 = new List<Image> ();
	public List<Image> imgKids2 = new List<Image> ();
	public List<Image> imgKids3 = new List<Image> ();
	public List<Image> imgKids4 = new List<Image> ();
	public List<Text> timers = new List<Text> ();
	public List<Image> imgDads = new List<Image> ();
	public List<Image> imgPowerUps = new List<Image> ();
	public List<Sprite> images = new List<Sprite> ();

	void Start () {
		imgKids.Add (imgKids1);
		imgKids.Add (imgKids2);
		imgKids.Add (imgKids3);
		imgKids.Add (imgKids4);
	}

	void Update () {
		if (Input.GetKeyDown("1")) {
			setPause ();
		}
	}

	public void createGame(int player) {
		nbrPlayer = player;
		hideAll ();
		for (int i = 0; i < nbrPlayer; i++) {
			families.Add (new Family (3, false, 0, 0, 0, false, 0));
			for (int j = 0; j < families [i].NbrKids; j++) {
				families [i].addKid (new Kid (j, 0));
			}
			afficherFam (i);
		}
	}

	public void hideAll() {
		for (int i = 0; i < panels.Count; i++) {
			panels[i].gameObject.SetActive(false);
		}
	}

	public void afficherFam(int numPlayer) {
		panels [numPlayer].gameObject.SetActive (true);
		imgDads[numPlayer].sprite = images[0];
		foreach (List<Image> imgKid in imgKids) {
			for (int i = 0; i < families [numPlayer].NbrKids; i++) {
				if (families [numPlayer].Kids [i].Status == -1) {
					imgKids[numPlayer][i].gameObject.SetActive (false);
				} else if (families [numPlayer].Kids [i].Status == 0) {
					imgKids[numPlayer][i].sprite = images [1];
				} else if (families [numPlayer].Kids [i].Status == 1) {
					imgKids[numPlayer][i].sprite = images [2];
				} else if (families [numPlayer].Kids [i].Status == 2) {
					imgKids[numPlayer][i].sprite = images [3];
				} else if (families [numPlayer].Kids [i].Status == 3) {
					imgKids[numPlayer][i].sprite = images [4];
				}
			}
		}

		if (families [numPlayer].PowerUp == -1) {
			imgPowerUps [numPlayer].gameObject.SetActive (false);
		} else if (families [numPlayer].PowerUp == 0) {
			imgPowerUps [numPlayer].sprite = images [5];
		} else if (families [numPlayer].PowerUp == 1) {
			imgPowerUps [numPlayer].sprite = images [6];
		} else if (families [numPlayer].PowerUp == 2) {
			imgPowerUps [numPlayer].sprite = images [7];
		} else if (families [numPlayer].PowerUp == 3) {
			imgPowerUps [numPlayer].sprite = images [8];
		}
		timers[numPlayer].text = families [numPlayer].ToString ();
	}

	public void setPause() {
		UI_Manager.ToggleUIInGame(false);
		UI_Manager.ToggleUIMenuPause (true);
	}
}
