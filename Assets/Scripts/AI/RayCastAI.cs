using UnityEngine;
using System.Collections;

public class RayCastAI : MonoBehaviour
{

	public float speed = 0.5f;
	public float vision = 10f; // distance that NPC can see
	public float visionSpread = 30f; //how large the vision is
	
	bool turnAround = false;
	bool doOnce = true;
	float turnState = 1;
	bool isCloseEnough = false;
	bool isInViewCone = false;
	bool isInLineOfSight = false;
	GameObject Player;
	
	bool normalMode = true;
	
	// Use this for initialization
	void Start ()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		isCloseEnough = (Vector3.Distance (transform.position, Player.transform.position) < vision) ? true : false;
		Vector3 targetDir = Player.transform.position - transform.position;
		Vector3 forward = transform.forward;
		isInViewCone = (Vector3.Angle (targetDir, forward) < visionSpread) ? true : false;
		Ray ray = new Ray (transform.position, targetDir);
		isInLineOfSight = Physics.Raycast (ray, vision);
		if (isCloseEnough && isInViewCone && isInLineOfSight) {
			normalMode = false;
			transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, speed * Time.deltaTime);
			renderer.material.color = Color.red;
		} else {
			normalMode = true;
			renderer.material.color = Color.green;
		}
	}
	
	// FixedUpdate is called once per physics frame / fixed timestep
	void FixedUpdate ()
	{
		if (normalMode) {
			
			// generate ray
			Ray ray = new Ray (transform.position, -transform.forward);
			
			//print (turnState);
			if (turnAround) {
				if (doOnce) {
					doOnce = false;
					
					transform.Rotate (0f, 90f, 0f);
				}
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				
				turnAround = false;
			} else {
				doOnce = true;
				GetComponent<Rigidbody> ().velocity = -transform.forward * speed;
			}
			
			if (Physics.Raycast (ray, 1f) && !turnAround) {
				turnAround = true;
				
			} 
		}
	}
}
