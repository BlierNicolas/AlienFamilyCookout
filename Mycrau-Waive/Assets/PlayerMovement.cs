using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody rb;
	Animator animator;
	PlayerScript player; 
	public Transform shotPos;
	public string joystick;
	public Material TeamMat = null;
	private bool canGrab = true;
	float speed = 40f;
	public AudioClip mangerFX;
	public AudioClip CracheFX;
	AudioSource audio;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		player = GetComponent<PlayerScript> ();
		audio = GetComponent<AudioSource> ();
	}


	void Update()
	{
		if (Input.GetButtonDown ("Fire1" + joystick)) 
		{

			if (player.Baby != null) 
			{
				//Debug.Log ("Not Null");
				ThrowBaby ();				
			} 
			else 
			{
				//Debug.Log ("Grab the baby");
				Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
				GrabTheBaby (colliders);
			}
		}
	}

	void GrabTheBaby(Collider[] cols)
	{
//		Debug.Log (cols.Length );
		if (canGrab) 
		{
			foreach (Collider trans in cols) 
			{
				if (trans.tag == "Baby") 
				{
					//Debug.Log ("Baby Grabed");
					animator.SetBool ("isEating", true);
					player.Baby = trans.gameObject;
					trans.gameObject.SetActive (false);
					audio.PlayOneShot (CracheFX);
					canGrab = false;
					StartCoroutine (GrabCoolDown());
					return;
				}
			}
		} 
		else 
		{
			//Debug.Log ("CoolDown isn't over");
		}
	}

	void ThrowBaby()
	{
			//Debug.Log ("Throw Baby");
			GameObject clone = player.Baby;
			player.Baby = null;

			GameObject rocketInstance;
			rocketInstance = Instantiate (clone, shotPos.position, shotPos.rotation) as GameObject;

			rocketInstance.SetActive (true); 
			rocketInstance.GetComponent<AIScript> ().Init ("RagDoll", TeamMat);
			//rocketInstance.GetComponent<Rigidbody> ().AddForce (shotPos.forward * 1f);
			audio.PlayOneShot (CracheFX);
			

	}
		
	void FixedUpdate()
	{
		float moveVertical = Input.GetAxis("Vertical" + joystick);

		float moveHorizontal = Input.GetAxis("Horizontal" + joystick);
		//Debug.Log ("Horizon: " + moveHorizontal + " Vertical: " + moveVertical);
		animator.SetFloat ("Speed", moveHorizontal + moveVertical);

		//Avance le player
		Vector3 movementNormalized = Vector3.Scale(Camera.main.transform.forward,new Vector3(1,0,1)).normalized;
		Vector3 m_move;
		m_move = moveVertical * movementNormalized + moveHorizontal * Camera.main.transform.right;
		rb.transform.position += m_move * speed * Time.fixedDeltaTime;
		//Effectue la rotation du player

		Vector3 look = m_move * speed * Time.fixedDeltaTime;
		if (look != Vector3.zero) 
		{
			transform.forward = m_move.normalized * Time.fixedDeltaTime;
		}
	}

	IEnumerator GrabCoolDown()
	{
		yield return new WaitForSeconds (1f);
		canGrab = true;
	}
}
