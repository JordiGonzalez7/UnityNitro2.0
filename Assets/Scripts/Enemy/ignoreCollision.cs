using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCollision : MonoBehaviour {
	[SerializeField]
	private Collider2D other;

	[SerializeField]
	private Collider2D other2;

	// Use this for initialization
	private void Awake () {
		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), other, true);

		Physics2D.IgnoreCollision (GetComponent<Collider2D> (), other2, true);
	}
	

}
