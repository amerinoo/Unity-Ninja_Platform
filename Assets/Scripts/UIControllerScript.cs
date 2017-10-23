using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
	public GameObject titleScreen;
	public GameObject gameScreen;
	public GameObject pausePanel;
	public GameObject gameStatusPanel;

	private GameControllerScript gcs;
	private Text health;
	private Text remainingTime;
	private Text points;
	// Use this for initialization
	void Start ()
	{
		gcs = GetComponent<GameControllerScript> ();
		health = gameStatusPanel.transform.Find ("Health").GetComponent<Text> ();
		remainingTime = gameStatusPanel.transform.Find ("RemainingTime").GetComponent<Text> ();
		points = gameStatusPanel.transform.Find ("Points").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		health.text = string.Format ("Health : {0}", gcs.health);
		remainingTime.text = string.Format ("Time : {0}", Mathf.RoundToInt (gcs.time));
		points.text = string.Format ("Points : {0}", gcs.points);
	}

	public void Pause ()
	{
		pausePanel.SetActive (true);
	}

	public void Resume ()
	{
		pausePanel.SetActive (false);
	}

	public void StartGame ()
	{
		titleScreen.SetActive (false);
		gameScreen.SetActive (true);
	}

	public void EndGame ()
	{
		titleScreen.SetActive (true);
		gameScreen.SetActive (false);
	}
}
