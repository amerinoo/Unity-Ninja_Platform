using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
	public BoxCollider2D playerCollider;
	public BoxCollider2D platformCollider;
	public BoxCollider2D platformTrigger;

	// Use this for initialization
	void Start ()
	{
		playerCollider = GameObject.FindGameObjectWithTag ("Player").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (platformCollider, platformTrigger);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Physics2D.IgnoreCollision (platformCollider, playerCollider);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Physics2D.IgnoreCollision (platformCollider, playerCollider, false);
		}
	}
	

}
