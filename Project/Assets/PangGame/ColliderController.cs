using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
	public PangGameControllerScript gcs;
	// Use this for initialization
	void Start ()
	{
		gcs = GameObject.FindWithTag ("GameController").GetComponent<PangGameControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (!other.CompareTag ("Player") && !other.CompareTag ("Wall")) {
			gcs.Trigger (transform, other);
			Destroy (gameObject);
		}
	}
}
