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

	SfxrSynth shotSynth;
	SfxrSynth hitSynth;
	void Start () {
		PlayShotSound();
		PlayHitSound();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Melee(){
	}


	public void Shoot(Vector3 playerPos, Vector3 targetPos){
		PlayShotSound();

		//shake amt relative to player
		Camera.main.gameObject.GetComponent<CamShake>().TriggerShake();
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


	public void PlayShotSound(){
		if (shotSynth == null) {
			shotSynth = new SfxrSynth();
			shotSynth.parameters.SetSettingsString("3,.223,,,,.1814,.456,.215,,-.286,-.132,.767,.523,.812,.975,.0487,,,.0397,,,.0469,,-.0094,,.751,-.321,.0016,.256,.03,,");
			shotSynth.SetParentTransform(Camera.main.transform);

		float ti = Time.realtimeSinceStartup;
			shotSynth.CacheMutations(15, 0.05f);
	}

		shotSynth.PlayMutated();

	}
	public void PlayHitSound(){
		if (hitSynth == null) {
			hitSynth = new SfxrSynth();
			hitSynth.parameters.SetSettingsString("3,.05,,.227,.5372,.2318,.3,.419,,-.3868,,,,,,,,,,,,,.5877,,,1,,,,,,");
			hitSynth.SetParentTransform(Camera.main.transform);
			
			float ti = Time.realtimeSinceStartup;
			hitSynth.CacheMutations(15, 0.06f);
		}
		
		hitSynth.PlayMutated();
		
	}



}
