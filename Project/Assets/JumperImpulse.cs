using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperImpulse : MonoBehaviour
{

	public float force;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
	}
}
