using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImpulse : MonoBehaviour
{
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Awake ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Move (Vector2 oldVel, int force)
	{
		rb2d.velocity = oldVel;
		rb2d.AddForce (new Vector2 (force, 2), ForceMode2D.Impulse);
	}
}
