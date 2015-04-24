using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	
	public Transform player;
	public float playerDistance;
	public float visionDistance;
	public float visionSpread = 45f; // angle between (npc's forward direction) and (line from npc to player)
	public float rotationDamping;
	public float chaseStartRange;
	public float speed;
	public float attackRange = 2f;

	public bool canSeePlayer = false;
	
	
	bool turnAround = false;
	bool doOnce = true;
	bool wallFix=true;
	
	// Use this for initialization
	void Start ()
	{
		transform.Rotate(Vector3.up* Random.Range(0,3)*90);
		player=GameObject.Find("Player").transform;
		
	}
	
	void Update ()
	{
		if (!canSeePlayer) {
			patrol ();
		}
		

			playerDistance = Vector3.Distance (player.position, transform.position);
			
			RaycastHit hit;
			
			if (playerDistance < visionDistance && 
			    Vector3.Angle (player.position - transform.position, transform.forward) < visionSpread && 
			    Physics.Raycast (transform.position, player.position - transform.position, out hit, visionDistance) && 
			    hit.collider.gameObject.tag == "Player") {
				canSeePlayer = true;
			if(!player.GetComponent<PlayerMoveQueueing>().stopEnemies){
			transform.LookAt(player.position);
			}
				//lookAtPlayer ();
			} else {
				canSeePlayer = false;
			}
			
			if (playerDistance < chaseStartRange) {
				if (playerDistance > attackRange) {
					chase (); 
				} else {
					attack ();
				}
			}
		
	}
	
	void lookAtPlayer ()
	{
		Debug.Log("looking at player");
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationDamping);
	}
	
	void patrol ()
	{
		
		Ray ray = new Ray (transform.position, transform.forward);
		if (turnAround) {
			if (doOnce) {
				doOnce = false;
				
				//transform.Rotate (0f, 90f, 0f);
				//transform.Rotate (0f, -90f, 0f);
				transform.Rotate (0f, 180f, 0f);
			}
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			
			turnAround = false;
		} else {
			doOnce = true;
			if(!player.GetComponent<PlayerMoveQueueing>().stopEnemies){
			GetComponent<Rigidbody> ().velocity = transform.forward * speed;
			}
			else{
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}
		}
		
		if (Physics.Raycast (ray, 1f) && !turnAround) {
			turnAround = true;
			
		} 
	}
	
	
	void chase ()
	{
		if(!player.GetComponent<PlayerMoveQueueing>().stopEnemies){
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}
	}
	
	void attack ()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.collider.gameObject.tag == "Player") {
				//hit.collider.gameObject.GetComponent<PlayerController> ().health -= 1f;
			}
		}
	}

	void OnCollisionStay(Collision col){
		if(col.gameObject.name=="Wall(Clone)"&&wallFix==true){
			wallFix=false;
			Invoke("ToggleWallFix",1f);
			transform.Rotate (0f, 180f, 0f);
		}

	}
	void ToggleWallFix(){
		wallFix=true;
	}
}