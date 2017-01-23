using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour {

	public PlayerScript m_owner;
	private Transform m_destination;
	private bool m_isMoving = false;

	//public GameObject Baby;
	//public GameObject RagDoll;
	private string m_State;

	private bool m_IsRagDoll = false;
	// Use this for initialization
	void Start () 
	{
		//State = "Patrol";
		
	}

	public void Init(string _state,Material _material)
	{
		State = _state;
		GetComponent<MeshRenderer> ().material = _material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (State) 
		{
		case "Patrol":
			//Debug.Log ("Patrol");
			if (!isMoving) 
			{
				isMoving = true;
				StartCoroutine (MoveOverSpeed (RandPos (),.5f));
			}
			break;
		case "RagDoll":
			if (!m_IsRagDoll)
			{
				m_IsRagDoll = true;
				Debug.Log ("RagDoll");
				StopAllCoroutines ();
				StartCoroutine(Buffer());
			}
			break;
		case "MicroWave":
			//Debug.Log("MicroWave");
			StopAllCoroutines();
			break;
		 default:
			//Debug.LogError("Forgot to Init the AI State");
			//Call init function in the instantiate of the AI 
			break;
			

		}
		//DEBUG
		if (Input.GetKeyDown (KeyCode.P)) {
			State = "Patrol";
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			State = "RagDoll";
		}
	}

	IEnumerator Buffer()
	{
		Debug.Log ("Buffer");
		yield return new WaitForSeconds (10f);
		State = "Patrol";
		m_IsRagDoll = false;
	}
	Vector3 RandPos()
	{
		return new Vector3 (Random.Range (-30, 30), 3f, Random.Range (-30, 30));
	}

	IEnumerator ChangeDestinationDelay()
	{
		StartCoroutine(MoveOverSpeed(RandPos(),.5f));
		yield return null;
	}
	public string State
	{
		get{return m_State; }
		set
		{
			//Debug.Log ("SETTERS: " + value);
			m_State = value; }
	}

	/*public IEnumerator MoveOverSeconds (Vector3 end, float seconds)
	{
		Debug.Log ("Move Over Second");
		float elapsedTime = 0;
		Vector3 startingPos = transform.position;
		while (elapsedTime < seconds)
		{
			Debug.Log ("Move");
			transform.position = Vector3.Lerp (startingPos, end, (elapsedTime / seconds));
			//transform.LookAt(end);
			var targetRotation = Quaternion.LookRotation(end - transform.position);

			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
			elapsedTime += Time.deltaTime;

			yield return new WaitForEndOfFrame();
		}
		transform.position = end;
		isMoving = false;
	}*/

	public IEnumerator MoveOverSpeed (Vector3 end, float speed)
	{
		// speed should be 1 unit per second
		float distance = Vector3.Distance(transform.position,end);

		while (distance > 3f)
		{
			//Debug.Log ("Distance: " + distance);
			distance = Vector3.Distance(transform.position,end);
			transform.position = Vector3.Lerp(transform.position, end, speed * Time.deltaTime);
			//transform.LookAt(end);
			var targetRotation = Quaternion.LookRotation(end - transform.position);

			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2 * Time.deltaTime);

			yield return new WaitForEndOfFrame ();
		}
		isMoving = false;
	}


	public bool isMoving
	{
		get{return m_isMoving; }
		set{m_isMoving = value; }
	}
}
	