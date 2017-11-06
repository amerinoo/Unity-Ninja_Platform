using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelScript : MonoBehaviour
{
	public string level;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void StartLevel ()
	{
		StaticData.level = level;
		SceneManager.LoadScene ("game");
	}
	
}
