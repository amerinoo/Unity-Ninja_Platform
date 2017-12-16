using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCube : MonoBehaviour
{
	public int counter;
	public int max;

	public GameObject tunel;
	public GameObject tunelFiller;

	public bool activated;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (counter >= max && !activated) {
			activated = true;
			tunel.GetComponent<Animation> ().Play ();
			tunelFiller.GetComponent<Animation> ().Play ();
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			counter += 1;
		}
	}
}
