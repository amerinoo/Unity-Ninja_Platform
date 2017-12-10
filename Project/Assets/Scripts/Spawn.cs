using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

	[SerializeField] public GameObject prefab;

	// Use this for initialization
	void Start ()
	{
		SpawnPrefab ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void SpawnPrefab ()
	{
		Instantiate (prefab, transform);
	}
}
