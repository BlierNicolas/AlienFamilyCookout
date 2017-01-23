using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (loadScene ());
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator loadScene()
	{
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene ("Jerome");
	}
}
