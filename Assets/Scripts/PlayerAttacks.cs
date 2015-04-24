using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttacks : MonoBehaviour {

	// Use this for initialization
	public GameObject bullet1;
	public Vector3 targetPos;
	public Vector3 direction;

	public float bulletDamage=50f;
	public int numShots=20;
	public float bulletSpeed=20f;
	public float shotArc=30f;
	public float shotVamp=5f;
	public float maxRange=10f;
	public Camera mainCam;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Melee(){
	}


	public void Shoot(Vector3 playerPos, Vector3 targetPos){

		//shake amt relative to player
		//Camera.main.gameObject.GetComponent<CamShake>().TriggerShake();
		direction= targetPos-playerPos;
		for(int i=0; i<numShots; i++){
			GameObject bullet= Instantiate(bullet1, playerPos,Quaternion.identity) as GameObject;
			bullet.transform.LookAt(targetPos);
			bullet.transform.Rotate(0f,Random.Range(-shotArc/2,shotArc/2),0f);
			bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*bulletSpeed*Random.Range(.8f,1.2f),ForceMode.Impulse);
			bullet.GetComponent<DestroyAfterTime>().shotDamage=bulletDamage;
			bullet.GetComponent<DestroyAfterTime>().startPos=playerPos;
			bullet.GetComponent<DestroyAfterTime>().endPos=targetPos;
			bullet.GetComponent<DestroyAfterTime>().range=maxRange;
			
		}
	}

}
