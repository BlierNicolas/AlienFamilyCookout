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
	public GameObject fam1, fam2, fam3, fam4;
	public List<List<Image>> imgKids = new List<List<Image>> ();
	public List<Image> imgKids1 = new List<Image> ();
	public List<Image> imgKids2 = new List<Image> ();
	public List<Image> imgKids3 = new List<Image> ();
	public List<Image> imgKids4 = new List<Image> ();
	public Image imgDad1, imgKid1_1, imgKid1_2, imgKid1_3, imgPU1;
	public Image imgDad2, imgKid2_1, imgKid2_2, imgKid2_3, imgPU2;
	public Image imgDad3, imgKid3_1, imgKid3_2, imgKid3_3, imgPU3;
	public Image imgDad4, imgKid4_1, imgKid4_2, imgKid4_3, imgPU4;
	public List<Text> timers = new List<Text> ();
	public List<Image> imgDads = new List<Image> ();
	public List<Image> imgPUs = new List<Image> ();
	public Text timer1, timer2, timer3, timer4;
	public List<Sprite> images = new List<Sprite> ();
	public Sprite IMG_DAD, IMG_BLOB_FREE, IMG_BLOB_PANIC, IMG_BLOB_COOK, IMG_BLOB_DEAD, IMG_POWERUP0, IMG_POWERUP1, IMG_POWERUP2, IMG_POWERUP3;

	void Start () {
		timers.Add (timer1);
		timers.Add (timer2);
		timers.Add (timer3);
		timers.Add (timer4);

		imgDads.Add (imgDad1);
		imgDads.Add (imgDad2);
		imgDads.Add (imgDad3);
		imgDads.Add (imgDad4);

		imgKids1.Add (imgKid1_1);
		imgKids1.Add (imgKid1_2);
		imgKids1.Add (imgKid1_3);
		imgKids2.Add (imgKid2_1);
		imgKids2.Add (imgKid2_2);
		imgKids2.Add (imgKid2_3);
		imgKids3.Add (imgKid3_1);
		imgKids3.Add (imgKid3_2);
		imgKids3.Add (imgKid3_3);
		imgKids4.Add (imgKid4_1);
		imgKids4.Add (imgKid4_2);
		imgKids4.Add (imgKid4_3);

		imgKids.Add (imgKids1);
		imgKids.Add (imgKids2);
		imgKids.Add (imgKids3);
		imgKids.Add (imgKids4);

		panels.Add (fam1);
		panels.Add (fam2);
		panels.Add (fam3);
		panels.Add (fam4);

		images.Add (IMG_DAD);
		images.Add (IMG_BLOB_FREE);
		images.Add (IMG_BLOB_PANIC);
		images.Add (IMG_BLOB_COOK);
		images.Add (IMG_BLOB_DEAD);
		images.Add (IMG_POWERUP0);
		images.Add (IMG_POWERUP1);
		images.Add (IMG_POWERUP2);
		images.Add (IMG_POWERUP3);

		imgPUs.Add (imgPU1);
		imgPUs.Add (imgPU2);
		imgPUs.Add (imgPU3);
		imgPUs.Add (imgPU4);
	}

	void Update () {
		if (Input.GetKeyDown("1")) {
			setPause ();
		}
	}

	public void createGame() {
		nbrPlayer = UI_Menu_Script.player;
		hideAll ();
		for (int i = 0; i < nbrPlayer; i++) {
			families.Add (new Family (3, false, 0, 0, 0, false, 0));
			for (int j = 0; j < families [0].NbrKids; j++) {
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
				//Debug.Log (numPlayer + " " + i);
				if (families [numPlayer].
					Kids [i].
					Status == -1) {
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
			imgPUs [numPlayer].gameObject.SetActive (false);
		} else if (families [numPlayer].PowerUp == 0) {
			imgPUs [numPlayer].sprite = images [5];
		} else if (families [numPlayer].PowerUp == 1) {
			imgPUs [numPlayer].sprite = images [6];
		} else if (families [numPlayer].PowerUp == 2) {
			imgPUs [numPlayer].sprite = images [7];
		} else if (families [numPlayer].PowerUp == 3) {
			imgPUs [numPlayer].sprite = images [8];
		}
		timers[numPlayer].text = families [numPlayer].ToString ();
	}

	public void setPause() {
		UI_Manager.ToggleUIInGame(false);
		UI_Manager.ToggleUIMenuPause (true);
	}
}
