using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMoveScript:MonoBehaviour
{
	public abstract void Move (EnemyControllerScript ecs);
}

