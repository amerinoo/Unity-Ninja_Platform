using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangGameControllerScript : MonoBehaviour
{
	public Transform ballsContainer;
	public GameObject bigBallPrefab;
	public GameObject mediumBallPrefab;
	public GameObject littleBallPrefab;
	public GameObject player;
	private GameObject map;

	// Use this for initialization
	void Start ()
	{
		int x = Random.Range (-15, 0);
		GameObject go;
		go = Instantiate (bigBallPrefab, new Vector2 (x, 12), Quaternion.Euler (Vector3.zero), ballsContainer);
		go.GetComponent<RandomImpulse> ().Move (Vector2.zero, 10);

		go = Instantiate (bigBallPrefab, new Vector2 (-x, 12), Quaternion.Euler (Vector3.zero), ballsContainer);
		go.GetComponent<RandomImpulse> ().Move (Vector2.zero, -10);
		GetComponent<PangUIController> ().Setup ();

		map = GameObject.FindGameObjectWithTag ("Level");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ballsContainer.childCount == 0) {
			NextLevel ();
		}
	}

	public void Trigger (Transform  iceBall, Collider2D other)
	{
		Vector2 pos = new Vector2 (other.transform.position.x, other.transform.position.y);

		Vector2 v = new Vector2 (iceBall.position.x, iceBall.position.y) - pos;
		v = new Vector2 (v.y, -v.x).normalized;

		Rigidbody2D rb2d = other.GetComponent<Rigidbody2D> ();
		Vector2 vel = new Vector2 (rb2d.velocity.x, rb2d.velocity.y);
		if (other.CompareTag ("Big")) {
			Split (mediumBallPrefab, pos, vel, v);
			player.SendMessage ("AddPoints", 100);
		} else if (other.CompareTag ("Medium")) {
			Split (littleBallPrefab, pos, vel, v);
			player.SendMessage ("AddPoints", 50);
		} else if (other.CompareTag ("Little")) {
			player.SendMessage ("AddPoints", 25);
		}
		Destroy (other.gameObject);
	}

	public void Split (GameObject prefab, Vector2 pos, Vector2 vel, Vector2 v)
	{
		float r = prefab.GetComponent<CircleCollider2D> ().radius;
		GameObject go;
		go = Instantiate (prefab, pos + v * r, Quaternion.Euler (Vector3.zero), ballsContainer);
		go.GetComponent<RandomImpulse> ().Move (vel, 5);

		go = Instantiate (prefab, pos - v * r, Quaternion.Euler (Vector3.zero), ballsContainer);
		go.GetComponent<RandomImpulse> ().Move (vel, -5);
	}

	public void NextLevel ()
	{
		StaticData.level = map.GetComponent <NextLevelInfo> ().nextLevel;
		if (StaticData.level.Equals ("---")) {
			GoGameCompleted ();
			return;
		}
		player.GetComponent<PangMovePlayerScript> ().Restart ();
	}

	public void GoCredits ()
	{
		Time.timeScale = 1.0f;
		UnityEngine.SceneManagement.SceneManager.LoadScene (StaticData.creditsScreen);
	}

	void GoGameCompleted ()
	{
		GoCredits ();
	}
}
