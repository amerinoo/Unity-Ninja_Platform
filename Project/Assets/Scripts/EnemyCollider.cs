using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
	public EnemyControllerScript ecs;

	// Use this for initialization
	void Awake ()
	{
		ecs = transform.parent.GetComponent<EnemyControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		ecs.Flip ();
	}
}
