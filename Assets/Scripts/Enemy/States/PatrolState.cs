using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : iEnemyState {
	
	private float patrolTimer;
	private float Patrolduration = 10;

	private PatchScript enemy;



	public void Execute ()
	{
		
		Patrol ();

		enemy.Move();
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

	private void Patrol(){
		

		patrolTimer += Time.deltaTime;

		if (patrolTimer >= Patrolduration) {
			enemy.ChangeState (new IdleState ());
		}
	}




}
