﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSelectLevelScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Go ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (StaticData.selectScreen);
	}
}
