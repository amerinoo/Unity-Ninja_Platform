using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	public float ttl = 1.0f;
	public float timer;
	// Use this for initialization
	void Start ()
	{
		timer = ttl;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			if (timer >= ttl) {
				timer = 0;
				other.transform.SendMessage ("DamagePlayer", 1);
			}
		}
	}
}
