using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMover : MonoBehaviour {

    public GameObject pointingObject = null;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(pointingObject.transform);
        transform.RotateAround(pointingObject.transform.position,Vector3.up,Time.deltaTime);
	}
}
