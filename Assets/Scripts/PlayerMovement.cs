using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed=2f;
	public Rigidbody rbody;
	void Start () {
		rbody= GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Move(float inputX, float inputY){
		rbody.AddForce(new Vector3(inputX,0f,inputY)*moveSpeed);
		//transform.Translate(new Vector3(inputX,0f,inputY)*moveSpeed);
	}
}
