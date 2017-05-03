﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;

	private Transform target;

	void Start () {

		target = GameObject.Find ("JotaroKujoStand_0").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate(){
	

		transform.position = new Vector3(Mathf.Clamp (target.position.x, xMin, xMax), Mathf.Clamp (target.position.y, yMin, yMax),transform.position.z);
	
	
	}







}
