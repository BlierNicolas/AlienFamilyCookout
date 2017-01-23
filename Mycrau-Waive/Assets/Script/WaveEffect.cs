using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEffect : MonoBehaviour {
	//public float radius = 20f;
	bool isEnter = false;
	bool AddForce = true;
	Collider[] Cols;

	Vector3 explosionPos;
	Collider[] colliders;


	// Use this for initialization
	void Start () 
	{
		Vector3 explosionPos = transform.position;
		//Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		
	}
	
	// Update is called once per frame
	void Update () 
	{


		//if (isEnter)
			//ApplyForce ();
	}


	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			AddForce = true;
			//Debug.Log ("Stay");
			isEnter = true;
			ApplyForce (col);
		}

		//col.GetComponent<AIScript> ().isActive = false;

	}
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player") 
		{
			//Debug.Log ("Exit");
			//StopAllCoroutines ();
			isEnter = false;
			AddForce = false;
		//col.GetComponent<AIScript> ().isActive = true;
		}

	}

	void ApplyForce(Collider col)
	{
		//Collider[] Cols = Physics.OverlapSphere(explosionPos, radius);
		//Debug.Log (Cols.Length);
		//foreach(Collider col in Cols)
		//{
			
		if (col.GetComponent<Rigidbody>() != null && AddForce &&isEnter) 
			{
				//col.GetComponent<AIScript> ().isActive = false;
				//Debug.Log ("Apply Force: " + col.name);
				col.GetComponent<Rigidbody> ().AddForce (transform.forward * 10000, ForceMode.Force);
				AddForce = false;
				//Debug.Log ("Start CoolDown");
				StartCoroutine (CoolDown (col));
			}

		//}
		//AddForce = false;
		//StartCoroutine (CoolDown ());
	}

	IEnumerator CoolDown(Collider col)
	{
		yield return new WaitForSeconds (.7f);
		//Debug.Log ("CoolDown Over");
		AddForce = true;
		ApplyForce (col);
	}
}
