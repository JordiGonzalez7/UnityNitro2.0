using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaCaida : MonoBehaviour {




	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D other) 
	{

		if (other.tag == "Player") {
			Destroy (gameObject);
		}


	}


}
