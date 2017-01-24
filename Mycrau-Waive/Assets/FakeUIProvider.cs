using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeUIProvider : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GameController.I.InitGame (2, 2, "FFA", true, 3);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
