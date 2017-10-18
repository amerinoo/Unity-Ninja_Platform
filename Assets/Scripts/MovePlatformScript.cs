using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformScript : MonoBehaviour
{
	public float stopDelay;
	private float travelTime = 3.0f;
	public bool invertDirection;

	public Vector3 origin;
	public Vector3 end;
	public bool backwards;
	public bool moving;

	private float timer;

	void Start ()
	{
		if (!invertDirection) {
			origin = transform.parent.position;
			end = transform.parent.Find ("Point").position;
		} else {
			origin = transform.parent.Find ("Point").position;
			end = transform.parent.position;
		}
		timer = 0.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		
		if (moving) {
			if (timer >= travelTime) { // He de parar
				timer -= travelTime;
				moving = false;
				backwards = !backwards;
			}
		} else { 
			if (timer >= stopDelay) { // He de mourem
				timer -= stopDelay;
				moving = true;
			}
		}

		if (moving) {
			move ();
		}
	}

	void move ()
	{
		float proportion = timer / travelTime;
		float t = (backwards) ? 1 - proportion : proportion;
		transform.position = Vector3.Lerp (origin, end, t);
	}

	public void ChangeDirection ()
	{
		timer = travelTime - timer;
		backwards = !backwards;
	}
}
