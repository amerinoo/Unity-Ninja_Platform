using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalDetectorScript : MonoBehaviour
{
	Transform parent;
	MovePlatformScript mps;
	public bool toRight;
	public bool imRight;

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
		toRight = mps.end.x - mps.origin.x < 0;
		imRight = transform.position.x > parent.transform.position.x;
		if (mps.moving) {
			if (!(imRight ^ toRight ^ mps.backwards) ^ mps.invertDirection) {
				parent.GetComponent<MovePlatformScript> ().ChangeDirection ();
			} 
		}
	}
}
