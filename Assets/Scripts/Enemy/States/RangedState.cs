using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : iEnemyState {

	private PatchScript enemy;

	public void Execute ()
	{
		if (enemy.InMeleeRange) {
		
			enemy.ChangeState (new MeleeState ());
		}

		if (enemy.Target != null) {
		
			enemy.Move ();

		} else {
			enemy.ChangeState (new IdleState ());
		}


	}



	public void Enter (PatchScript enemy)
	{
		this.enemy = enemy;
	}

	public void Exit ()
	{

	}

	public void OnTriggerEnter (Collider2D other)
	{

	}

}
