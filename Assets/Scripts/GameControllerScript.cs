using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
	public static GameControllerScript instance = null;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (!instance.Equals (this))
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
