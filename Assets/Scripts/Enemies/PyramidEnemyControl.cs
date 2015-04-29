using UnityEngine;
using System.Collections;

public class PyramidEnemyControl : MonoBehaviour {

	// Use this for initialization
	public Transform player;
	public bool canSeePlayer = false;
	public float visionDistance;
	public bool turning=false;
	public bool lookingAtPlayer=false;
	public bool shooting=false;
	public bool delayBeforeFirstShot=true;
	public float firstShotDelay=.2f;
	public float delayBetweenLaterShots=.5f;
	public float delayBetweenShotsDuringTimeStop=1.5f;
	public int numEnemyShots=10;
	public float enemyShotArc=30f;
	public float enemyBulletSpeed=500f;
	public GameObject enemyBullet;
	public float turnDistance=5f;
	public float moveSpeed=1f;
	public float moveSpeedDuringPause=.01f;

	public float rotateSpeed=1f;
	public float timeStopRotateSpeed=.5f;

	public LayerMask bulletMask;
	void Start () {
		player=GameObject.Find("Player").transform;
		StartCoroutine("ShootingAtPlayer");
		StartCoroutine("TurnCoroutine");

	}
	
	// Update is called once per frame
	void Update () {

		//Ray forwardRay = new Ray (transform.position, transform.TransformDirection(Vector3.forward););
		Ray playerRay = new Ray (transform.position, player.position-transform.position);
		RaycastHit forwardHit;
		RaycastHit hit;

		if (Physics.Raycast(playerRay, out hit,visionDistance)){
			if(hit.collider.gameObject==player.gameObject){
				canSeePlayer=true;

				Vector3 fwd = transform.TransformDirection(Vector3.forward);
			if (Physics.Raycast (transform.position,fwd , out forwardHit)) {
				if(forwardHit.collider.gameObject==player.gameObject){
					shooting=true;
					}
					else{
					shooting=false;
					}
				}
			}
			else{
				canSeePlayer=false;
				shooting=false;
			}
		}
		
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit movementHit;
		if( Physics.Raycast(ray,out movementHit,turnDistance)){
			if(movementHit.collider.tag=="Walls"){
				float rando=Random.Range(0f,1f);
				if(rando<.5f){
				transform.Rotate (0f,90f,0f);
				}
				else{
				transform.Rotate (0f,-90f,0f);

				}

			}
		}
		if(!canSeePlayer){

			if(!player.GetComponent<PlayerMoveQueueing>().timeStopped){
			transform.Translate (Vector3.forward * moveSpeed);
			}

			/*
			if(player.GetComponent<PlayerMoveQueueing>().timeStopped){
				transform.Translate (Vector3.forward * moveSpeedDuringPause);
			}
			else{
			transform.Translate (Vector3.forward * moveSpeed);
			}
			*/
		}
	}

	IEnumerator TurnCoroutine(){

		while(true){
			if(canSeePlayer && !player.GetComponent<PlayerMoveQueueing>().timeStopped){
		Vector3 targetDir = player.position - transform.position;
				float step;
				if(player.GetComponent<PlayerMoveQueueing>().timeStopped){
				 step = timeStopRotateSpeed * Time.deltaTime;
				}
				else{
				 step = rotateSpeed * Time.deltaTime;
				}
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		//Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
				yield return 0;
			}
			yield return 0;
		}
	}

	IEnumerator ShootingAtPlayer(){

		while(true){
			if(shooting){
				if(delayBeforeFirstShot){
					delayBeforeFirstShot=false;
					yield return new WaitForSeconds(firstShotDelay);
				}
				Shoot();

				if(!player.GetComponent<PlayerMoveQueueing>().timeStopped){
				yield return new WaitForSeconds(delayBetweenLaterShots);
				}
				else{
				yield return new WaitForSeconds(delayBetweenShotsDuringTimeStop);
				}
			}
		//Shoot ();
			yield return 0;
			}
		}
	

		void Shoot(){
		//Debug.Log("called");
		for(int i=0; i<numEnemyShots; i++){

			Vector3 startPos= transform.position+transform.forward*3f;
			GameObject bullet= Instantiate(enemyBullet, startPos,Quaternion.identity) as GameObject;
			bullet.transform.LookAt(player.transform.position);
			bullet.transform.Rotate(0f,Random.Range(-enemyShotArc/2,enemyShotArc/2),0f);
			Vector3 bulletForce=(Vector3.forward*enemyBulletSpeed*Random.Range(.8f,1.2f));
			bullet.GetComponent<Rigidbody>().AddRelativeForce(bulletForce,ForceMode.Impulse);

			bullet.GetComponent<BulletSpeedControl>().startSpeed=bulletForce.z;
		}
	}



	void FixedUpdate(){

}

}
	