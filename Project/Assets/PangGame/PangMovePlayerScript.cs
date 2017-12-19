#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR
#define KEYBOARD_PLATFORM
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PangMovePlayerScript : MonoBehaviour
{

	[HideInInspector] public bool facingRight = true;

	public float maxSpeed = 8f;
	public GameObject shootPrefab;
	public Transform spawn;
	//public Animator anim;
	public Rigidbody2D rb2d;
	private Quaternion calibrationQuat;
	public int lives;
	public int points;

	Animator anim;
	bool pause;
	PangUIController uics;
	float ttl;
	float ttlMax = 0.5f;


	// Use this for initialization
	void Awake ()
	{
		uics = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PangUIController> ();
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
		if (pause) {

		} else {
			ttl += Time.deltaTime;
			if (IsPlayerDead ()) {
				PlayerDead ();
			} else {
				if (Input.GetKeyDown (KeyCode.Escape)) {
					Pause ();
				}
				if (ttl > ttlMax && (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Jump"))) {
					ttl = 0;
					GameObject go = Instantiate (shootPrefab, spawn.position, Quaternion.identity);
					go.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 10), ForceMode2D.Impulse);
					Destroy (go, 5);
				}
			}
		}
	}

	public void GoMain ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (StaticData.mainScreen);
	}

	public void Restart ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (StaticData.pangScreen);
	}

	void FixedUpdate ()
	{
		if (!IsPlayerDead () && !pause) {
			float h;
			#if KEYBOARD_PLATFORM
			h = Input.GetAxis ("Horizontal");
			#else
			h = FixAcceleration (Input.acceleration);
			#endif

			anim.SetFloat ("Speed", Mathf.Abs (h));
			rb2d.velocity = new Vector2 (h * maxSpeed, 0);


			if (h > 0 && !facingRight) {
				Flip ();
			} else if (h < 0 && facingRight) {
				Flip ();
			}
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

	public void AddPoints (int p)
	{
		points += p;
	}

	void Damage ()
	{
		lives--;
	}


	void OnCollisionEnter2D (Collision2D coll)
	{
		if (!coll.gameObject.CompareTag ("Shoot") && !coll.gameObject.CompareTag ("Wall"))
			Damage ();
	}

	bool IsPlayerDead ()
	{
		return lives < 0;
	}

	void PlayerDead ()
	{
		anim.SetTrigger ("die");
		Debug.Log ("You die!");
		BeforeEndLevel ();	
	}

	void BeforeEndLevel ()
	{
		Invoke ("EndGame", GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().GetCurrentAnimatorClipInfo (0).Length + 0.1f);
	}

	void EndGame ()
	{
		GameObject.FindGameObjectWithTag ("Level").GetComponent<AudioSource> ().Stop ();
		Time.timeScale = 0.0f;
		uics.EndGame ();
	}

	public void Pause ()
	{
		pause = true;
		uics.Pause ();
		Time.timeScale = 0.0f;
	}

	public void Resume ()
	{
		pause = false;
		uics.Resume ();
		Time.timeScale = 1.0f;
	}

	void OnApplicationPause (bool pauseStatus)
	{

		if (pauseStatus)
			Pause ();
		else
			Resume ();
	}
}
