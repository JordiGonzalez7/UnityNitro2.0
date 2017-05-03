using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIOWALL : MonoBehaviour {



	void OnTriggerEnter2D (Collider2D col) 
	{
		
		//Check collision name
		//Debug.Log("collision name = " + col.gameObject.name);
		if(col.gameObject.name == "StarPlatinum_0 1(Clone)")
		{
			Destroy(col.gameObject);
		}


	}
}
