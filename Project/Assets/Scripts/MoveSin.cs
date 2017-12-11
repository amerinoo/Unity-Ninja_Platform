using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : IMoveScript
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	#region IMoveScript implementation

	public override void Move (EnemyControllerScript ecs)
	{
		float h = ecs.facingRight ? 1.0f : -1.0f;
		transform.position += new Vector3 (0.1f * h, Mathf.PingPong (Time.time, 0.5f) - 0.25f, 0);
	}

	#endregion
}
