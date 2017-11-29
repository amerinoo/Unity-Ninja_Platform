using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class ElevatorScript : MonoBehaviour
{
	public int max;
	public int step;
	public List<Transform> points;

	private int nextFloor;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < max; i++) {
			GameObject go = new GameObject (i.ToString ());
			go.transform.parent = transform.parent;			
			go.transform.localPosition = new Vector3 (0, i * step, 0);
			points.Add (go.transform);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	[Task]
	bool ChooseFloor ()
	{
		nextFloor = Random.Range (0, points.Count);
		return true;
	}

	[Task]
	void SetColor ()
	{
		float f = nextFloor / (points.Count * 1.0f);
		GetComponent<Renderer> ().material.color = Color.HSVToRGB (f, 1.0f, 1.0f);
		Task.current.Succeed ();
	}

	[Task]
	void Go ()
	{
		Transform t = points [nextFloor];

		transform.position = Vector3.Lerp (transform.position, t.position, Time.deltaTime);
		if (Vector3.Distance (transform.position, t.position) < 0.3f) {

			GetComponent<Renderer> ().material.color = Color.HSVToRGB (Random.Range (0.0f, 1.0f), 1.0f, 1.0f);

			Task.current.Succeed ();
		}
	}
}
