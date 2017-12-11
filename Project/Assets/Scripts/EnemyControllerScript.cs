using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour
{
	public bool facingRight = true;

	public float health;
	public float maxSpeed = 3f;
	public float acceleration = 10f;
	public Animator anim;
	public Rigidbody2D rb2d;
	public bool invertDirection;
	public Vector3 origin;
	public Vector3 end;
	public Vector3 target;
	public bool diee;
	public int points;
	public float minDistance = 0.5f;
	public IMoveScript moveScript;

	// Use this for initialization
	void Awake ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		moveScript = GetComponent<IMoveScript> ();
		if (!invertDirection) {
			origin = transform.parent.position;
			end = transform.parent.Find ("Point").position;
		} else {
			origin = transform.parent.Find ("Point").position;
			end = transform.parent.position;
		}
		transform.parent.position = origin;
	}
		

	// Update is called once per frame
	void Update ()
	{
		if (diee) {
			diee = false;
			die ();
		}

		if (facingRight && Vector3.Distance (transform.position, end) < minDistance) {
			Flip ();
		} else if (!facingRight && Vector3.Distance (transform.position, origin) < minDistance) {
			Flip ();
		}
	}

	void FixedUpdate ()
	{
		if (health <= 0f) {
			
		} else {
			moveScript.Move (this);
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			health--;
			if (health <= 0f) {
				die ();
			}
			other.GetComponent<StatusController> ().GivePoints (points);
			other.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 25f), ForceMode2D.Impulse);
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Flip ();
		if (other.transform.CompareTag ("Player")) {
			other.transform.SendMessage ("DamagePlayer", 1);
		}
	}


	void die ()
	{
		health = 0f;
		rb2d.velocity = Vector3.zero;
		anim.SetTrigger ("Death");
		Destroy (transform.parent.gameObject, 0.6f);
	}
}
