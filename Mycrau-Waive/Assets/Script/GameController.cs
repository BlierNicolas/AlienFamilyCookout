using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	int m_Round;
	int m_NbPlayer;
	string m_GameMode;
	bool m_powerUps; 
	int m_Timer;

	GameController m_Instance;


	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this);
	}

	public void InitGame(int nbPlayer, int nbRound,string gameMode, bool powerUps, int timer )
	{
		InitPlayer (nbPlayer);	
		InitPowerUps (powerUps);
	}

	public void InitPlayer(int nbPlayer)
	{
		for(int i = 1; i< nbPlayer; i++)
		{
			//Instanciate Player 
			//Instantiate Family 
			//Instanciate Micro wave 
			//SetColor 
		}
	}
	public void InitPowerUps(bool powerUps)
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public static GameController I
	{
		get 
		{
			if (I == null)
			{
				I = new GameController();
			}
			return I;
		}
		set{I = value; }
	}
}
