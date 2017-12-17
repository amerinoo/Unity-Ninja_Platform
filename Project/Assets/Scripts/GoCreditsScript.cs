using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCreditsScript : MonoBehaviour
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
		UnityEngine.SceneManagement.SceneManager.LoadScene (StaticData.creditsScreen);
	}
}
