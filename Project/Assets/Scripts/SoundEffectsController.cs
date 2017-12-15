using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{

	public AudioClip damage;
	public AudioClip jump;

	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void PlayDamage ()
	{
		Play (damage);
	}

	public void PlayJump ()
	{
		Play (jump);
	}

	void Play (AudioClip clip)
	{
		audioSource.clip = clip;
		audioSource.Play ();
	}
}
