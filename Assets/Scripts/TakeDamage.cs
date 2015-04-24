using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	// Use this for initialization
	public float maxHealth=100f;
	public float healthSizeRatio=30f;
	public float currentHealth=100f;
	public float timeSinceDamage=2f;
	public float delayToHeal=1f;
	public float healSpeed=.01f;
	public bool scaling=false;
	public AnimationCurve bounceCurve;

	void Start () {
		//transform.localScale=Vector3.one* maxHealth/healthSizeRatio;
		StartCoroutine("Scaler");

	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth<0f){
			currentHealth=0f;
		}
		if(Input.GetKeyDown(KeyCode.O)){
			StartCoroutine("ScaleBackOut");
		}

	}
	
	IEnumerator ScaleBackOut(){
		Keyframe key = new Keyframe();
		float firstKeyVal=currentHealth/maxHealth;
		key.value=firstKeyVal;
		Keyframe[] curveKeys = bounceCurve.keys;
		curveKeys[0]=key;
		bounceCurve.keys=curveKeys;

		float i =0f;
		while(i<1f){
			currentHealth=maxHealth*bounceCurve.Evaluate(i);
			i+=healSpeed;
			yield return 0;
		}
	}

	IEnumerator Scaler(){
		while(Application.isPlaying){

			transform.localScale = Vector3.one*currentHealth/healthSizeRatio;

				yield return 0;
		}
	}
}
