#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR
#define KEYBOARD_PLATFORM
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayerScript : MonoBehaviour
{

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;

	public float maxSpeed = 8f;
	public float jumpForce = 700f;
	public Transform groundCheck;
	public LayerMask whatIsGround;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private float circleRadius = 0.25f;
	private Quaternion calibrationQuat;



	// Use this for initialization
	void Awake ()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();

	}

	void CalibrateAccelerometer ()
	{
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuat = Quaternion.FromToRotation (
			                        new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuat = Quaternion.Inverse (rotateQuat);
	}

	// Update is called once per frame
	void Update ()
	{
		bool jump = Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Jump");
		if (jump && grounded) {
			//anim.SetTrigger ("Jump");
			rb2d.AddForce (new Vector2 (0f, jumpForce));

			
		}
	}

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, circleRadius, whatIsGround);

		float h;
		#if KEYBOARD_PLATFORM
		h = Input.GetAxis ("Horizontal");
		#else
		h = FixAcceleration (Input.acceleration);
		#endif

		anim.SetFloat ("Speed", Mathf.Abs (h));
		if (Mathf.Abs (h) > 0.01) {
			rb2d.velocity = new Vector2 (h * maxSpeed, rb2d.velocity.y);
		}

		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}

	}

	float FixAcceleration (Vector3 acceleration)
	{
		acceleration = calibrationQuat * acceleration;
		if (acceleration.x < 0.1 && acceleration.x > -0.1)
			return 0;
		else if (acceleration.x > 0.1)
			return 1;
		else
			return -1;

	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.transform.CompareTag ("MovingPlatform"))
			transform.parent = other.transform;
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.transform.CompareTag ("MovingPlatform"))
			transform.parent = null;
	}
}
