using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInitPositionScript : MonoBehaviour
{
	Vector3 initPosition;
	// Use this for initialization
	void Start ()
	{
		initPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void GoInitPosition ()
	{
		transform.position = initPosition;
	}
}
