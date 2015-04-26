using UnityEngine;
using System.Collections;

public class BulletSpeedControl : MonoBehaviour {

	// Use this for initialization
	public Rigidbody rbody;
	public PlayerMoveQueueing playerScript;
	public float startSpeed;
	public bool restartImpulse=false;
	public float speedDuringPause=.5f;
	void Start () {
		rbody=GetComponent<Rigidbody>();
		playerScript=GameObject.FindWithTag("Player").GetComponent<PlayerMoveQueueing>();
		//startSpeed=rbody.velocity;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(playerScript.timeStopped){
			restartImpulse=true;
			rbody.drag=10f;
			//transform.Translate(Vector3.forward*speedDuringPause);
			//rbody.velocity=Vector3.forward*startSpeed*slowFactor;
			//Debug.Log("stopped");
		}
		else{
			if(restartImpulse){
				rbody.drag=0f;
				restartImpulse=false;
			rbody.AddRelativeForce(Vector3.forward*startSpeed,ForceMode.Impulse);
			}
			//rbody.velocity=Vector3.forward*startSpeed;
		}

	}
}
