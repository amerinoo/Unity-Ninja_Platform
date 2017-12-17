using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSelectLevelScript : MonoBehaviour
{

	public float time;

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
		StaticData.time = time;
		UnityEngine.SceneManagement.SceneManager.LoadScene (StaticData.selectScreen);
	}
}
