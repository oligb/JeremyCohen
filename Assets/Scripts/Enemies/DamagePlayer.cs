using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	// Use this for initialization
	public float singleBulletDamage=1f;
	public GameObject hitParticle;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag=="Player"){

			if(!col.gameObject.GetComponent<PlayerMoveQueueing>().timeStopped){	
				Instantiate(hitParticle,transform.position,Quaternion.Euler(90f,0f,0f));
			col.gameObject.GetComponent<PlayerMoveQueueing>().currentEnergy-=singleBulletDamage;
			Destroy(gameObject);
			}
		}
		else if(col.gameObject.tag=="Walls"){
			Destroy(gameObject);
		}
	}
}
