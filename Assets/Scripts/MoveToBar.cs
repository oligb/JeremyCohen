using UnityEngine;
using System.Collections;

public class MoveToBar : MonoBehaviour {

	// Use this for initialization
	public float speed=.1f;
	public Transform secretTarget;
	public float endScale=.1f;
	public GameObject player;
	public float energyRestored=5f;

	void Start () {
		//player=GameObject.FindWithTag("Player");
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
		Vector3 startPos = transform.position;
		Vector3 startScale= transform.localScale;
		float i =0f;
		while (i<=2f){
			Debug.Log(i);
			transform.position=Vector3.Lerp(startPos,secretTarget.position,i);
			transform.localScale=Vector3.Lerp(startScale,Vector3.one*endScale,i/2);
				i+=speed;
				yield return 0;
		}
		player.GetComponent<PlayerMoveQueueing>().currentEnergy+=energyRestored;
		Destroy(gameObject);
	}
}
