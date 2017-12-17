using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PangUIController : MonoBehaviour
{
	public GameObject gameScreen;
	public GameObject gameOver;

	public GameObject pausePanel;
	public GameObject gameStatusPanel;

	private PangGameControllerScript gcs;
	private PangMovePlayerScript mps;

	private GameObject health;
	private Text points;
	// Use this for initialization
	void Start ()
	{
		
	}


	// Update is called once per frame
	void Update ()
	{
		if (mps != null) {
			health.GetComponent<HealthUpdateUI> ().Update (mps.lives);
			points.text = string.Format ("Points : {0}", mps.points);
		}
	}

	public void Setup ()
	{
		gcs = GetComponent<PangGameControllerScript> ();
		mps = gcs.player.GetComponent<PangMovePlayerScript> ();
		health = gameStatusPanel.transform.Find ("Health").gameObject;
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

	public void EndGame ()
	{
		gameScreen.SetActive (false);
		gameOver.SetActive (true);
	}
}
