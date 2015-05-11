using UnityEngine;
using System.Collections;

public class TriggerUpgradePoint : MonoBehaviour {

	// Use this for initialization
	public int pointValue=1;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player"){
			col.gameObject.GetComponent<PlayerUpgradeManager>().currentUpgradePoints+=pointValue;
			StartCoroutine("Pickup");
			Destroy (GetComponent<BoxCollider>());
			Destroy (GetComponent<MeshRenderer>());
		}
	}
	
	IEnumerator Pickup(){
		GetComponent<ParticleSystem>().Stop();
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
