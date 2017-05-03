using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : iEnemyState {

	private PatchScript enemy;

	private float idleTimer;

	private float idleduration = 5;

	public void Execute ()
	{

		Idle ();
		if (enemy.Target != null) {
			enemy.ChangeState (new PatrolState ());
		
		}
	}

	public void Enter (PatchScript enemy)
	{
		this.enemy = enemy;
	}

	public void Exit ()
	{

	}

	public void OnTriggerEnter2D(Collider2D other)
	{

	}

	private void Idle(){
		enemy.ani.SetFloat ("speed", 0);

		idleTimer += Time.deltaTime;

		if (idleTimer >= idleduration) {
			enemy.ChangeState (new PatrolState ());
		}
	}

}
