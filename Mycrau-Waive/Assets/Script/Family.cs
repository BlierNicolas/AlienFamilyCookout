using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : System.Object {

	public static int MICRO_TIME_COOK = 10;
	public static int MICRO_TIME_BREAK = 10;
	public static int POWER_UP_TIME = 10;

	private int nbrKids;
	private List<Kid> kids = new List<Kid> ();
	private bool haveKid;
	private Kid whoKid;
	private int microStatus;
	private int temps;
	private int score;
	private bool powerupAct;
	private int powerup;

	public Family(int nbrKids, bool haveKid, int microStatus, int temps, int score, bool powerupAct, int powerup) {
		NbrKids = nbrKids;
		HaveKid = haveKid;
		MicroStatus = microStatus;
		Temps = temps;
		Score = score;
		PowerUpAct = powerupAct;
		PowerUp = powerup;
	}

	public int NbrKids {
		get { return nbrKids; }
		set { nbrKids = value; }
	}

	public List<Kid> Kids {
		get { return kids; }
		set { kids = value; }
	}
	public void addKid(Kid kid) {
		kids.Add (kid);
	}

	public bool HaveKid {
		get { return haveKid; }
		set { haveKid = value; }
	}

	public Kid WhoKid {
		get { return whoKid; }
		set { whoKid = value; }
	}

	public int MicroStatus {
		get { return microStatus; }
		set {
			if ((value < -1) || (value > 2)) {
				microStatus = 0;
			} else {
				microStatus = value;
			}
		}
	}

	public int Temps {
		get { return temps; }
		set {
			if (value <= 0) {
				temps = 0;
			} else {
				temps = value; 
			}
		}
	}

	public int Score {
		get { return score; }
		set {
			if (value <= 0) {
				score = 0;
			} else {
				score = value; 
			}
		}
	}
	public void addScore() {
		score++;
	}

	public bool PowerUpAct {
		get { return powerupAct; }
		set { powerupAct = value; }
	}

	public int PowerUp {
		get { return powerup; }
		set { 
			if ((value <0) || (value > 4)) {
				powerup = 0;
			} else {
				powerup = value;
			}
		}
	}

	public string ToString() {
		string text = "";
		if (Score < 10) {
			text = "0";
		}
		text += Score + " ";
		
		if (Temps < 10) {
			text += "0";
		}
		text += Temps;
		
		return text;
	}
}
