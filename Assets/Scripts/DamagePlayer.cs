using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	// Use this for initialization
	public float singleBulletDamage=1f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag=="Player"){
			if(!col.gameObject.GetComponent<PlayerMoveQueueing>().timeStopped){		
			col.gameObject.GetComponent<PlayerHealthManager>().currentHealth-=singleBulletDamage;
			Destroy(gameObject);
			}
		}
		else{
			Destroy(gameObject);
		}
	}
}
