using UnityEngine;
using System.Collections;

public class MoveToBar : MonoBehaviour {

	// Use this for initialization
	public float speed=.1f;
	public Transform secretTarget;
	public float endScale=.1f;
	public GameObject player;
	public float energyRestored=5f;
	SfxrSynth shotSynth;

	void Start () {
		player=GameObject.FindWithTag("Player");
		secretTarget=GameObject.FindWithTag("SecretBarPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
	
		if(col.gameObject==player){
			Destroy(GetComponent<BoxCollider>());
			Destroy(GetComponent<Rigidbody>());
			StartCoroutine("SwoopToBar");
		}
	}


	IEnumerator SwoopToBar(){
		player.GetComponent<PlayerAttacks>().PlayPickupSound();
		Vector3 startPos = transform.position;
		Vector3 startScale= transform.localScale;
		//Vector3 targetPos= secretTarget.position;
		float i =0f;
		while (i<=2f){
			//Debug.Log(i);
			transform.position=Vector3.Lerp(startPos,secretTarget.position,i);
			transform.localScale=Vector3.Lerp(startScale,Vector3.one*endScale,i/2);
				i+=speed;
				yield return 0;
		}
		player.GetComponent<PlayerMoveQueueing>().currentEnergy+=energyRestored;
		Destroy(gameObject);
		yield break;
	}

}
