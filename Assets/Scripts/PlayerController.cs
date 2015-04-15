﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public float moveSpeed=2f;
	public Rigidbody rbody;
	public bool canMove=true;
	

	void Start () {
		rbody= GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float inputX =  Input.GetAxis("Horizontal")*Time.deltaTime;
		float inputY =  Input.GetAxis("Vertical")*Time.deltaTime; 

	if(canMove){
		rbody.AddForce(new Vector3(inputX,0f,inputY)*moveSpeed);
	}

	}



}

