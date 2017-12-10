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

	Rigidbody2D rb;
	float speedX;
	float speedY;

	void Start ()
	{
		if (!invertDirection) {
			origin = transform.parent.position;
			end = transform.parent.Find ("Point").position;
		} else {
			origin = transform.parent.Find ("Point").position;
			end = transform.parent.position;
		}
		transform.parent.position = origin;
		timer = 0.0f;
		rb = GetComponent<Rigidbody2D> ();
		speedX = (end.x - origin.x) / travelTime;
		speedY = (end.y - origin.y) / travelTime;
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		
		if (moving) {
			if (timer >= travelTime) { // He de parar
				timer -= travelTime;
				moving = false;
				rb.velocity = new Vector2 (0f, 0f);
				backwards = !backwards;
			}
		} else { 
			if (timer >= stopDelay) { // He de mourem
				timer -= stopDelay;
				moving = true;
				move ();
			}
		}
	}

	void move ()
	{
		float factor = (backwards) ? -1 : 1;
		rb.velocity = new Vector2 (speedX * factor, speedY * factor);
	}

	public void ChangeDirection ()
	{
		timer = travelTime - timer;
		backwards = !backwards;
		move ();
	}
}
