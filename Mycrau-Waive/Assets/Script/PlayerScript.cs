using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Material m_PlayerColor;
	private GameObject m_Baby;//Le bebe manger
	public GameObject[] m_Family;
	//private PowerUps 

	// Use this for initialization
	void Start () 
	{
		initBaby (3);
		
	}
	
	// Update is called once per frame
	void Update () 
	{


	}

	void initBaby(int nbBaby)
	{
		for (int i = 0; i < nbBaby; i++) 
		{
			m_Family [0] = Resources.Load ("AIBaby") as GameObject;
			AIScript ai = m_Family [i].GetComponent<AIScript> ();
			ai.State = "Patrol";
			ai.m_owner = this;
			ai.TeamColor = PlayerColor;
		}
	}

	public GameObject Baby
	{
		get{return m_Baby; }
		set
		{
			//Debug.Log ("Baby Set");
			m_Baby = value; }
	}

	public Material PlayerColor
	{
		get {return m_PlayerColor; }
		set { m_PlayerColor = value; }
	}
}
