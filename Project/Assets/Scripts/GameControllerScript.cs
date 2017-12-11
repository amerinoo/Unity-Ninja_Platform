using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	public float time;
	public bool pause;
	public GameObject player;
	public bool playerDead;

	private UIControllerScript uics;
	private GameObject map;

	public bool debug;

	// Use this for initialization
	void Awake ()
	{
		if (debug) {
			player = GameObject.Find ("Remove").transform.GetChild (1).gameObject;
			map = GameObject.Find ("Remove").transform.GetChild (0).gameObject;
		} else {
			GameObject.Find ("Remove").SetActive (false);
			player = Instantiate (Resources.Load ("Characters/" + StaticData.character))as GameObject;
			map = Instantiate (Resources.Load ("Levels/" + StaticData.level))as GameObject;
		}
		player.transform.position = map.transform.Find ("Skeleton/InitialPoint").transform.position;
		uics = GetComponent<UIControllerScript> ();
		uics.Setup ();
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1))
			player.SendMessage ("DamagePlayer", 1);
		
		if (Input.GetKeyDown (KeyCode.Alpha2))
			player.SendMessage ("GivePoints", 10);
		
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			GiveTime (50);
			player.SendMessage ("DamagePlayer", -3);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}

		if (pause) {
			
		} else {
			time -= Time.deltaTime;
			if (time <= 0.0f || PlayerDead ()) {
				GameObject.FindGameObjectWithTag ("Level").GetComponent<AudioSource> ().Stop ();
				EndGame ();
			}			
		}
	}

	bool PlayerDead ()
	{
		return playerDead;
	}

	public void PlayerDead (int playerNum)
	{
		playerDead = true;
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

	public void EndGame ()
	{
		uics.EndGame ();
		Time.timeScale = 0.0f;
	}

	public void Restart ()
	{
		SceneManager.LoadScene (2);
	}

	public void NextLevel ()
	{
		StaticData.level = map.GetComponent <NextLevelInfo> ().nextLevel;
		if (StaticData.level.Equals ("---")) {
			GoGameCompleted ();
			return;
		}
		Restart ();
	}

	void GiveTime (int i)
	{
		this.time += i;
	}


	public void GoMenu ()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("main");
	}

	void GoGameCompleted ()
	{
		GoMenu ();
	}

	void OnApplicationPause (bool pauseStatus)
	{
		
		if (pauseStatus)
			Pause ();
	}
}
