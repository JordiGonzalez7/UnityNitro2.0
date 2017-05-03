using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class StarP : MonoBehaviour {



	[SerializeField]
	private float speed;

	private Rigidbody2D myRB;

	protected Animator ani;


	//private Collider2D col2D;



	private Vector2 direction;


	// Use this for initialization
	void Start () {

		myRB = GetComponent<Rigidbody2D> ();
		//col2D = GetComponent<Collider2D> ();
		ani = GetComponent<Animator>();
		//direction = Vector2.right;


	}


	void FixedUpdate(){
		myRB.velocity = direction * speed;
	
	}

	public void Initialize(Vector2 direction){

		this.direction = direction;

	}


	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}


	void OnCollisionEnter2D (Collision2D other) 
	{
		

		
			Destroy (gameObject);






	}

}
