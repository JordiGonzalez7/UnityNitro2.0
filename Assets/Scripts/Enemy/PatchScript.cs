using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchScript : Character
{
	[SerializeField]
	private float meleeRange;

	private iEnemyState currentState;

	public GameObject Target  { get; set;}

	public bool InMeleeRange  { 
		get {
			if (Target != null) {
			
				return Vector2.Distance (transform.position, Target.transform.position) <= meleeRange;
			
			}
			return false;
		} 

	}

	// Use this for initialization
	public override void  Start ()
	{
		base.Start ();

		Controller.Instance.Dead += new DeadEventHandle (removeTarget);

		ChangeState(new IdleState());

	}


	
	// Update is called once per frame
	void Update ()
	{


		if(!IsDead){

			if (!TakingDamage) {
				currentState.Execute ();

			}

			LookAtTarget ();

		}

	}

	public void removeTarget(){
	
		Target = null;

		ChangeState (new PatrolState ());
	
	}

	private void LookAtTarget()
	{
		if(Target != null){

			float xDir = Target.transform.position.x - transform.position.x;
			if (xDir < 0 && facingRight || xDir > 0 && !facingRight) {
				ChangeDirc ();
			}


		}
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


	public override void OnTriggerEnter2D (Collider2D other){
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);
	}

	public override bool IsDead { 

		get{ 
			return health <= 0;
		}


	}

	public override void Death(){
	
		Destroy (gameObject);

	}

	public override IEnumerator TakeDamege (){

		health -= 10;

		if (!IsDead) {
			Debug.Log ("hit");
			ani.SetTrigger ("hit");
		} else {
			Debug.Log ("muerto");
			ani.SetTrigger ("muerto");
			yield return null;
		}
	}

}
