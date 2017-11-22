using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryKiller : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("Enter");
		if (other.CompareTag ("Player")) {
			other.GetComponent<StatusController> ().Suicide ();
		}
	}
}
