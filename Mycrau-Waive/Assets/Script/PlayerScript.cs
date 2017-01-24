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
		m_Family = new GameObject[nbBaby];
		for (int i = 0; i < nbBaby; i++) 
		{
			m_Family [i] = Resources.Load ("AIBaby") as GameObject;
			AIScript ai = m_Family [i].GetComponent<AIScript> ();
			ai.Init ("Patrol", PlayerColor);
			ai.m_owner = this;
			//ai.TeamColor = PlayerColor;
			Instantiate (m_Family [i], RandPos (), Quaternion.identity);
			//m_Family [i].transform.position = RandPos ();
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

	Vector3 RandPos()
	{
		return new Vector3 (Random.Range (-30, 30), 3f, Random.Range (-30, 30));
	}
}
