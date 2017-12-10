using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDetectorScript : MonoBehaviour
{
	Transform parent;
	MovePlatformScript mps;

	// Use this for initialization
	void Start ()
	{
		parent = transform.parent;
		mps = parent.GetComponent<MovePlatformScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (mps.backwards ^ mps.invertDirection) {
			mps.ChangeDirection ();
		} 
	}
}
