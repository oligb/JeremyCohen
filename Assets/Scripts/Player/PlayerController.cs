using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public float moveSpeed=2f;
	public bool canMove=true;
	public float maxSpeed=15f;
	Rigidbody rbody;
	Vector3 velocity;
	float startDrag;

	void Start () {

		rbody= GetComponent<Rigidbody>();
		startDrag=rbody.drag;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float inputX =  Input.GetAxis("Horizontal");
		float inputY =  Input.GetAxis("Vertical");


		if(inputX==0f && inputY==0f){
			rbody.drag=20f;
		}
		else{
			rbody.drag=startDrag;
		}




		Vector3 direction = new Vector3(0,0,0);

		if (Input.GetKey ("a")){
			direction -= Vector3.right;
		}
		if(Input.GetKey("d")){
			direction += Vector3.right;
		}
		if (Input.GetKey ("w")){
			direction += Vector3.forward;     
		}
		if(Input.GetKey ("s")){
			direction -= Vector3.forward;
		}
	
		if (direction != Vector3.zero){
			if(canMove){
	    		rbody.AddForce(direction.normalized*moveSpeed*Time.deltaTime);
			}

				             
			//rbody.AddForce(new Vector3(inputX,0f,inputY)*moveSpeed*Time.deltaTime);
	}
		velocity=rbody.velocity;
		if(velocity.magnitude> maxSpeed){
	
		velocity.x=Mathf.Clamp(velocity.x,-maxSpeed,maxSpeed);
		velocity.z=Mathf.Clamp(velocity.z,-maxSpeed,maxSpeed);
		rbody.velocity=velocity;
		}	
			//rbody.velocity.magnitude=maxSpeed;



		}


}

