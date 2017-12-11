using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinear : IMoveScript
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
		ecs.rb2d.AddForce (new Vector2 (h * ecs.acceleration, 0), ForceMode2D.Force);
		if (ecs.rb2d.velocity.x > ecs.maxSpeed) {
			ecs.rb2d.velocity = new Vector2 (ecs.maxSpeed, ecs.rb2d.velocity.y);
		} else if (ecs.rb2d.velocity.x < -ecs.maxSpeed) {
			ecs.rb2d.velocity = new Vector2 (-ecs.maxSpeed, ecs.rb2d.velocity.y);
		}
	}

	#endregion
}
