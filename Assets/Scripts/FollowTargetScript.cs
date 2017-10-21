using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetScript : MonoBehaviour
{
	public Transform target;

	public bool YMaxEnabled = false;
	public float YMaxValue = 0.0f;

	public bool YMinEnabled = false;
	public float YMinValue = 0.0f;

	public bool XMaxEnabled = false;
	public float XMaxValue = 0.0f;

	public bool XMinEnabled = false;
	public float XMinValue = 0.0f;

	private Vector3 velocity = Vector3.zero;
	private float smoothTime = 0.15f;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 targetPos = target.position;

		if (YMinEnabled && YMaxEnabled)
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, YMaxValue);
		else if (YMinEnabled)
			targetPos.y = Mathf.Clamp (target.position.y, YMinValue, target.position.y);
		else if (YMaxEnabled)
			targetPos.y = Mathf.Clamp (target.position.y, target.position.y, YMaxValue);

		if (XMinEnabled && XMaxEnabled)
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, XMaxValue);
		else if (XMinEnabled)
			targetPos.x = Mathf.Clamp (target.position.x, XMinValue, target.position.x);
		else if (XMaxEnabled)
			targetPos.x = Mathf.Clamp (target.position.x, target.position.x, XMaxValue);

		targetPos.z = transform.position.z;
		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);
	}
}
