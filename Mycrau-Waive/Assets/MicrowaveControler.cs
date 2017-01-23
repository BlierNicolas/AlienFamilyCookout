using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveControler : MonoBehaviour {

    private float COOKINGTIME = 10.0f;
	public PlayerScript p_owner;
    private Collider inCookBaby;
    Animator Animator;
    private bool isActive;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioClip clip;
	public AudioClip clip2;

	void Awake()
	{
		List<AudioSource> list  = new List<AudioSource>(GetComponents<AudioSource> ());
		list.Add (audio1);
		list.Add (audio2);
		audio1 = list [0];
		audio2 = list [1];
	}
    // Use this for initialization
    void Start () {
		
        inCookBaby = null;
        isActive = false;
    }

	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Baby")
        {
			other.GetComponent<AIScript>().State = "MicroWave";
			audio1.PlayOneShot (clip);
			audio2.PlayOneShot (clip2);
            inCookBaby = other;
        }
    
    }

    public void StartCooking()
    {
        if (inCookBaby != null)
        {
            CloseDoor(true);
            isActive = true;
            StartCoroutine(Cooking(COOKINGTIME));
           
        }
    }

    public void StopCooking() {
        if (inCookBaby != null)  {
            //StopCoroutine(Cooking(COOKINGTIME));
            StopAllCoroutines();
            CloseDoor(false);
            inCookBaby.transform.position = new Vector3(0, 30, 0);
        }


    }

    private void KillingTheBaby(Collider other) {
        ChangeStatus((int)status.Dead);
        //StopCoroutine(Cooking(COOKINGTIME));
        StopAllCoroutines();
        inCookBaby = null;
    }

    private void ChangeStatus(int status) {
        switch (status)
            {
                case 1:
                //inCookBaby.GetComponent<>.SetStatus();
                break;
                case 2:
                //inCookBaby.GetComponent<>.SetStatus();
                break;
                case 3:
                //inCookBaby.GetComponent<>.SetStatus();
                break;
                case 4:
                //inCookBaby.GetComponent<>.SetStatus();
                break;
                case 5:
                //inCookBaby.GetComponent<>.SetStatus();
                break;
                default:
                        break;
            }    
    }
    


    private void CloseDoor(bool isClosing)
    {
        //animation here!
        if (isClosing)
        {

        }
        else
        {

        }
    }


    IEnumerator Cooking(float waitTime) {
        while (isActive)
        {
            yield return new WaitForSeconds(waitTime);
            print("DIIING!!!!! " + Time.time);
            isActive = false;
            KillingTheBaby(inCookBaby);
        }
    }


}

enum status
{
    Dead = 1, Alive = 2, Block = 3, Occuper = 4, Cooking = 5
};