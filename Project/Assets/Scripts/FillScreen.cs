using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillScreen : MonoBehaviour
{

	// Use this for initialization

	public float speed = 0.5f;
	public bool vertical;

	void Start ()
	{
		if (vertical) {
			float quadHeight = Camera.main.orthographicSize * 2.0f;
			float quadWidth = quadHeight * Screen.width / Screen.height;
			transform.localScale = new Vector3 (quadHeight, quadWidth, 1f);
			transform.localRotation = Quaternion.Euler (0, 0, -90);
			transform.position = new Vector3 (0, 1, 0);
		} else {
			float quadHeight = Camera.main.orthographicSize * 2.0f;
			float quadWidth = quadHeight * Screen.width / Screen.height;
			transform.localScale = new Vector3 (quadWidth, quadHeight, 1f);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 offset = new Vector2 (Time.time * speed, 0);
		GetComponent<MeshRenderer> ().material.mainTextureOffset = offset;
	}
}
