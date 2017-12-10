using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class MovePlatformPanda : MonoBehaviour
{
	public Transform start;
	public Transform end;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	[Task]
	void SetColor (float r, float g, float b)
	{
		Color c = new Color (r, g, b);
		GetComponent<Renderer> ().material.color = c;
		Task.current.debugInfo = c.ToString ();
		Task.current.Succeed ();
	}

	[Task]
	void Move (bool left)
	{
		Transform t = (left) ? start : end;

		transform.position = Vector3.Lerp (transform.position, t.position, Time.deltaTime);
		if (Vector3.Distance (transform.position, t.position) < 0.3f) {
			Task.current.Succeed ();
		}
	}
}
