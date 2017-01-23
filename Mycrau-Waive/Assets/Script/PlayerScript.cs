using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Color m_PlayerColor;
	private GameObject m_Baby;
	public GameObject[] m_Family;
	//private PowerUps 

	// Use this for initialization
	void Start () 
	{
		
		foreach (GameObject blob in m_Family) 
		{
			blob.GetComponent<AIScript>().State = "Patrol";
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{


	}



	public GameObject Baby
	{
		get{return m_Baby; }
		set
		{
			//Debug.Log ("Baby Set");
			m_Baby = value; }
	}
}
