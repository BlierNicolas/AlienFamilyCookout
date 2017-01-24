using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour 
{
	GameObject powerUps;
	const int POWER_UPS_DELAY = 10;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (DelaySpawn());
		powerUps = Resources.Load ("PowerUpsPrefabs") as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator DelaySpawn()
	{
		yield return new WaitForSeconds (POWER_UPS_DELAY);
		SpawnRandom ();
	}

	public void SpawnRandom()
	{
		Debug.Log ("Spawn");
		GameObject clone;
		clone = Instantiate (powerUps, RandPos (), transform.rotation) as GameObject;
		Destroy (clone, POWER_UPS_DELAY);
		StartCoroutine (DelaySpawn ());
	}
		
	Vector3 RandPos()
	{
		return new Vector3 (Random.Range (-20, 20), 1, Random.Range (-20, 20));
	}
	
}
