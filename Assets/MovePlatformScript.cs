using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformScript : MonoBehaviour
{
	public float stopDelay;
	public float travelTime;

	private Vector3 origin;
	private Vector3 end;

	private bool moving;
	private bool backwards;
	private float timer;

	void Start ()
	{
		origin = transform.parent.position;
		end = transform.parent.Find ("Point").position;
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
			float proportion = timer / travelTime;
			float t = (backwards) ? 1 - proportion : proportion;
			transform.position =   (origin, end, t);
		}
	}
}
