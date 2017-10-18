using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalDetectorScript : MonoBehaviour
{
	Transform parent;
	MovePlatformScript mps;
	bool toUp;

	// Use this for initialization
	void Start ()
	{
		parent = transform.parent;
		mps = parent.GetComponent<MovePlatformScript> ();
		toUp = mps.origin.y - mps.end.y < 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("a");
		if (!(toUp ^ mps.backwards)) {
			mps.ChangeDirection ();
		} 
	}
}
