using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpdateUI : MonoBehaviour
{
	public List<Transform> hearts;
	public Sprite heartFull;
	public Sprite heartEmpty;

	// Use this for initialization
	void Start ()
	{
		foreach (Transform heart in transform) {
			hearts.Add (heart);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Update (int health)
	{
		for (int i = 0; i < hearts.Count; i++) {
			hearts [i].GetComponent<UnityEngine.UI.Image> ().sprite = health <= i ? heartEmpty : heartFull;
		}
	}
}
