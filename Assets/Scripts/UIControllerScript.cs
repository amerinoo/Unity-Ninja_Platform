using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
	public GameObject pausePanel;
	public GameObject gameStatusPanel;

	private GameControllerScript gcs;
	private StatusController sc;
	private Text health;
	private Text remainingTime;
	private Text points;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		if (sc != null) {
			health.text = string.Format ("Health : {0}", sc.health);
			points.text = string.Format ("Points : {0}", sc.points);
		}
		if (gcs != null) {
			remainingTime.text = string.Format ("Time : {0}", Mathf.RoundToInt (gcs.time));
		}
	}

	public void Setup ()
	{
		gcs = GetComponent<GameControllerScript> ();
		sc = gcs.player.GetComponent<StatusController> ();
		health = gameStatusPanel.transform.Find ("Health").GetComponent<Text> ();
		remainingTime = gameStatusPanel.transform.Find ("RemainingTime").GetComponent<Text> ();
		points = gameStatusPanel.transform.Find ("Points").GetComponent<Text> ();
	}

	public void Pause ()
	{
		pausePanel.SetActive (true);
	}

	public void Resume ()
	{
		pausePanel.SetActive (false);
	}
}
