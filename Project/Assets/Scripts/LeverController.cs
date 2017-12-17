using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class LeverController : MonoBehaviour
{
	public GameObject[] cubes;
	public int selectedCube;
	public int success;
	public int successMax;
	public bool isCollidingPlayer;
	public GameObject objectFound;

	public AudioSource audioSource;
	public AudioClip leverSound;
	public AudioClip wrongSound;
	public AudioClip foundSound;

	public GameObject[] greens;

	bool resetGreens;

	// Use this for initialization
	void Start ()
	{
		successMax = greens.Length;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	[Task]
	public void ChooseCube ()
	{
		GetComponent<Animation> ().Play ();
		audioSource.clip = leverSound;
		audioSource.Play ();
		selectedCube = Random.Range (0, cubes.Length);
		Task.current.Succeed ();
	}

	[Task]
	public void SetColor ()
	{
		cubes [selectedCube].GetComponent<Renderer> ().material.color = Color.white;
		Task.current.Succeed ();
	}

	[Task]
	public void CheckCubes ()
	{
		if (CheckCollisions ()) {
			success += 1;
			cubes [selectedCube].GetComponent<Renderer> ().material.color = Color.green;
			greens [success - 1].GetComponent<Renderer> ().material.color = Color.green;
			if (success >= successMax) {
				GetComponent<BoxCollider2D> ().enabled = false;
				transform.parent.Find ("Cubes").gameObject.SetActive (false);
				objectFound.SetActive (true);
				audioSource.clip = foundSound;
				audioSource.Play ();
			}
			Task.current.Succeed ();
		} else {
			success = 0;
			audioSource.clip = wrongSound;
			audioSource.Play ();
			foreach (GameObject cube in greens) {
				cube.GetComponent<Renderer> ().material.color = Color.red;
			}
			resetGreens = true;
			Task.current.Fail ();
		}
	}

	bool CheckCollisions ()
	{
		bool others = false;
		for (int i = 0; i < cubes.Length; i++) {
			if (cubes [i].GetComponent<LeverCube> ().HasCollidedPlayer && selectedCube != i) {
				cubes [i].GetComponent<Renderer> ().material.color = Color.red;
				others = true;
			}
		}
		return cubes [selectedCube].GetComponent<LeverCube> ().HasCollidedPlayer && !others;
	}

	[Task]
	public void Reset ()
	{
		foreach (GameObject cube in cubes) {
			cube.GetComponent<Renderer> ().material.color = Color.black;
			cube.GetComponent<LeverCube> ().HasCollidedPlayer = false;
		}
		if (resetGreens) {
			resetGreens = false;
			foreach (GameObject cube in greens) {
				cube.GetComponent<Renderer> ().material.color = Color.white;
			}
		}
		Task.current.Succeed ();
	}

	[Task]
	bool IsCollidingPlayer {
		get{ return isCollidingPlayer; }
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Player"))
			isCollidingPlayer = true;      
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.CompareTag ("Player"))
			isCollidingPlayer = false;       
	}
}
