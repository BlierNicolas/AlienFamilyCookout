﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOnFight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(0,30,0);
    }
}