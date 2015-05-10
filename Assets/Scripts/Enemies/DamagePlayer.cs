using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	// Use this for initialization
	public float singleBulletDamage=1f;
	public GameObject hitParticle;
	SfxrSynth shotSynth;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag=="Player"){

			if(!col.gameObject.GetComponent<PlayerMoveQueueing>().timeStopped){	
				PlayShotSound();
				Instantiate(hitParticle,transform.position,Quaternion.Euler(90f,0f,0f));
				Camera.main.gameObject.GetComponent<CamShake>().TriggerShake();
			col.gameObject.GetComponent<PlayerMoveQueueing>().currentEnergy-=singleBulletDamage;
			Destroy(gameObject);
			}
		}
		else if(col.gameObject.tag=="Walls"){
			Destroy(gameObject);
		}
	}


	public void PlayShotSound(){
		shotSynth = new SfxrSynth();
		shotSynth.parameters.SetSettingsString("4,.5,.0452,.6048,.1281,.9085,.9188,.5347,,.0377,.0363,-.0381,-.18,.7448,.7864,.9618,.8507,-.3596,-.8709,.7911,.8067,-.0005,.4318,.0004,,.9942,.0043,.9161,.0006,-.0002,.4298,.7089");
		shotSynth.Play();
		
	}


}
