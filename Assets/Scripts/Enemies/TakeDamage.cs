using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TakeDamage : MonoBehaviour {

	// Use this for initialization

	public GameObject hitParticle;
	public float enemyHealth=100f;
	bool hitOnce=true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(enemyHealth<=0f){
			KillEnemy();
		}
	}


	public void KillEnemy(){

		if(hitOnce){
			hitOnce=false;
		GetComponent<EnemyDrops>().DropStuff();
		Instantiate(hitParticle,transform.position,Quaternion.Euler(90f,0f,0f));
		Destroy(gameObject);
		}
	}
}
