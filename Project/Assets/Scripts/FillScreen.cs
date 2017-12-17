using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScreen : MonoBehaviour {

	// Use this for initialization

	public float speed = 0.5f;

	void Start () {
        float quadHeight = Camera.main.orthographicSize * 2.0f;
        float quadWidth = quadHeight * Screen.width / Screen.height;
        transform.localScale = new Vector3(quadWidth, quadHeight, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset;
    }
}
