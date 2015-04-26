using UnityEngine;
using System.Collections;

public class DestroyGuy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	if(transform.localScale.x<=1f){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name=="Player"){

			col.gameObject.GetComponent<KillPlayer>().Kill();
		}
	}
}
