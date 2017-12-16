using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCubeGoal : MonoBehaviour
{
	public GameObject objectFound;
	public bool rightCube;

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
		if (other.gameObject.CompareTag ("Player") && !objectFound.activeSelf) {  
			transform.parent.GetComponent<AudioSource> ().Play ();
			if (rightCube)
				objectFound.SetActive (true);
			GetComponent<Animation> ().Play ();
		}
	}
}
