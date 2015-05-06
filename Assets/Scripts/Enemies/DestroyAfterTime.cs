using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	// Use this for initialization
	public float startTime=0f;
	public float lifeTime=5f;
	public Vector3 startPos, endPos;
	public float range;

	public float shotDamage=5f;
	void Start () {
		startTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(transform.position,startPos)>range){
			Destroy(gameObject);
		}
	
		if(Time.time-startTime>lifeTime){
			Destroy(gameObject);
	}
	}

	
	void OnCollisionEnter(Collision col){

		if(col.gameObject.GetComponent<DamagePlayer>() != null){
			Destroy(col.gameObject);
		}
		else if(col.gameObject.GetComponent<TakeDamage>() !=null){
			col.gameObject.GetComponent<TakeDamage>().enemyHealth-=shotDamage;

		}
		else if(col.gameObject.GetComponent<PunchingBagDamage>() != null){
			col.gameObject.GetComponent<PunchingBagDamage>().currentHealth-=shotDamage;	
			col.gameObject.GetComponent<PunchingBagDamage>().timeSinceDamage=0f;
			Destroy(gameObject);
		}
	}
}
