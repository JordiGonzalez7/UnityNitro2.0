using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


	public Transform SpawnPoint;



	[SerializeField]
	public GameObject prefab;




	void OnTriggerEnter2D(Collider2D other){
	
		if (other.tag == "Player") {


			GameObject tmp = (GameObject)Instantiate (prefab, SpawnPoint.position,Quaternion.identity);
			Rigidbody2D rbPre = tmp.AddComponent<Rigidbody2D> ();
			rbPre.mass = 5;
			rbPre.gravityScale = 5;


		}
	
	}


}
