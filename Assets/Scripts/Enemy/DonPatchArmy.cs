using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonPatchArmy : MonoBehaviour {
	 
	protected Animator ani;
	protected Collider2D col2D;

	void Start () {



		ani = GetComponent<Animator>();
		col2D = GetComponent<Collider2D>();
	}


	void OnCollisionEnter2D (Collision2D col) 
	{
		//Check collision name

		if(col.gameObject.name == "StarPlatinum_0 1(Clone)")
		{
			
			Destroy(col.gameObject);







		}
	}
}
