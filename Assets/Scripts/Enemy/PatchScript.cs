using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchScript : Character
{

	private iEnemyState currentState;

	// Use this for initialization
	public override void  Start ()
	{
		base.Start ();
		ChangeState(new IdleState());

	}
	
	// Update is called once per frame
	void Update ()
	{
		currentState.Execute ();
	}

	public void ChangeState (iEnemyState newState)
	{
		if (currentState != null) {
			currentState.Exit ();
		}
		currentState = newState;
		currentState.Enter (this);

	}

	public Vector2 GetDirection(){

		return facingRight ? Vector2.right : Vector2.left;

	}

	public void Move()
	{

		ani.SetFloat ("speed", 1);

		transform.Translate (GetDirection () * (speed * Time.deltaTime),Space.World);

	}
}
