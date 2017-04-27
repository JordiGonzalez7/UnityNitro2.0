using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iEnemyState{


	void Execute();
	void Enter(PatchScript enemy);
	void Exit();
	void OnTriggerEnter(Collider2D other);





}
