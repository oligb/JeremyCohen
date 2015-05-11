using UnityEngine;
using System.Collections;

public class armorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider item){

		if(item.gameObject.name.StartsWith("bullet1")){
			Debug.Log("ArmorHit");
//			item.gameObject.GetComponent<DestroyAfterTime>().isActive = false;
//			item.transform.Rotate(0,160 + Random.Range(0,40),0);
//			item.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);
			Destroy(item);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
