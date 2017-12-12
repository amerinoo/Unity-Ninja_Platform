using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkin : MonoBehaviour
{
	public string[] names;
	public int index;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < names.Length; i++) {
			if (names [i].Equals (StaticData.character)) {
				index = i;
				break;
			}
		}
		if (CompareTag ("Player"))
			ChangeSkin ();
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void ChangeSkin ()
	{
		GetComponent<Animator> ().runtimeAnimatorController = Resources.Load ("Characters/" + StaticData.character)as RuntimeAnimatorController;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			index = (index + 1) % names.Length;
			StaticData.character = names [index];
			other.gameObject.GetComponent <CharacterSkin> ().ChangeSkin ();
		}
	}
}
