using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkinSelector : MonoBehaviour
{

	public RuntimeAnimatorController[] skins;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Animator> ().runtimeAnimatorController = skins [Random.Range (0, skins.Length)];
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
