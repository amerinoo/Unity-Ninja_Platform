using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverCube : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public bool hasCollided;

	public bool HasCollidedPlayer {
		get {
			return hasCollided;
		}
		set {
			hasCollided = value;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			hasCollided = true;    
			transform.parent.GetComponent<Animation> ().Play ();
		}
	}
}
