using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchSight : MonoBehaviour {

	[SerializeField]
	private PatchScript enemy;


	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player") {
			enemy.Target = other.gameObject;
		} 
		/*
		if (other.tag == "edge") {
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), other, true);
		}
		*/



	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			enemy.Target = null;
		}
	}
}
