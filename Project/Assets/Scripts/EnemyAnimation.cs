using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : IMoveScript
{
	public Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	#region IMoveScript implementation

	public override void Move (EnemyControllerScript ecs)
	{
		float horizontal = ecs.facingRight ? 1.0f : -1.0f;

		ecs.rb2d.AddForce (new Vector2 (horizontal * ecs.acceleration, 0), ForceMode2D.Force);

		horizontal = ecs.health < 2 ? horizontal * 0.2f : horizontal;
		if (Mathf.Abs (ecs.rb2d.velocity.x) > ecs.maxSpeed) {
			ecs.rb2d.velocity = new Vector2 (ecs.maxSpeed * horizontal, ecs.rb2d.velocity.y);
		}

		anim.SetFloat ("speed", Mathf.Abs (horizontal));
	}

	#endregion
}
