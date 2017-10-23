using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
	public static GameControllerScript instance = null;
	public float health;
	public float time;
	public float points;

	private UIControllerScript uics;
	private bool pause = true;

	void Awake ()
	{
		Time.timeScale = 0.0f;
		if (instance == null) {
			instance = this;
		} else if (!instance.Equals (this))
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		
	}
	// Use this for initialization
	void Start ()
	{
		uics = GetComponent<UIControllerScript> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.H))
			DamagePlayer (10);
		
		if (Input.GetKeyDown (KeyCode.G))
			GivePoints (10);
		
		if (pause) {
			
		} else {
			time -= Time.deltaTime;
			if (time <= 0.0f || health <= 0.0f)
				EndGame ();
			
		}
	}

	public void StartGame ()
	{
		BroadcastMessage ("GoInitPosition");
		health = 100.0f;
		time = 120.0f;
		points = 0.0f;
		uics.StartGame ();
		Resume (); 
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
		Time.timeScale = 0.0f;
		uics.EndGame ();
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}

	public void DamagePlayer (int damage)
	{
		health -= damage;
	}

	public void GivePoints (int points)
	{
		this.points += points;
	}
}
