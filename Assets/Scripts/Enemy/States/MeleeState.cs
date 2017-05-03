using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : iEnemyState
{

	private PatchScript enemy;

	private float attackTimer;
	private float attackCooldown = 4;
	private bool canAttack = true;


	public void Execute ()
	{
		Attack ();
		if (!enemy.InMeleeRange) {
		
			enemy.ChangeState (new RangedState ());
		} else if (enemy.Target == null) {
		
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

	public void OnTriggerEnter2D (Collider2D other)
	{
		
	}

	private void Attack(){
	
		attackTimer += Time.deltaTime;

		if (attackTimer >= attackCooldown) {
		
			canAttack = true;
			attackTimer = 0;
		
		}

		if (canAttack) {
		
			canAttack = false;
			enemy.ani.SetTrigger ("Ora");
		
		}


	
	}



}
