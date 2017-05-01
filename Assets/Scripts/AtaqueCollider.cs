using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCollider : MonoBehaviour {

	[SerializeField]
	private string target;

	void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == target) {
		
			GetComponent<Collider2D> ().enabled = false; 
		}
	
	}
}
