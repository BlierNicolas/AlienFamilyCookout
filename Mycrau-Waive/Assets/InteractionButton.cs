using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : MonoBehaviour {

    public GameObject microOnde;
    public bool typeButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("button "+ typeButton);
            if (typeButton)
                microOnde.GetComponent<MicrowaveControler>().StartCooking();
            else
                microOnde.GetComponent<MicrowaveControler>().StopCooking();
        }

    }

}
