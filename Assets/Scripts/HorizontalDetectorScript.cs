using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDetectorScript : MonoBehaviour
{
	Transform parent;
	MovePlatformScript mps;
	bool toRight;
	bool imRight;

	// Use this for initialization
	void Start ()
	{
		parent = transform.parent;
		mps = parent.GetComponent<MovePlatformScript> ();
		toRight = mps.origin.x - mps.end.x < 0;
		imRight = transform.position.x < parent.transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (mps.moving) {
			if (!(imRight ^ toRight ^ mps.backwards)) {
				parent.GetComponent<MovePlatformScript> ().ChangeDirection ();
			} 
		}
	}
}
