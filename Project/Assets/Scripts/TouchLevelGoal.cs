using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLevelGoal : MonoBehaviour
{

	public GameControllerScript gcs;
	// Use this for initialization
	void Start ()
	{
		gcs = GameObject.FindGameObjectWithTag ("GameController").GetComponent< GameControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			gcs.NextLevel ();
		}
	}
}
