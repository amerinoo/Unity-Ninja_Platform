using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJump : IMoveScript
{
	public float forceX;
	public float forceY;

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

		if (Mathf.Abs (ecs.rb2d.velocity.y) == 0) {
			ecs.rb2d.AddForce (new Vector2 (h * forceX, forceY), ForceMode2D.Impulse);
		}
	}

	#endregion
}
