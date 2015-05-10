using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupByPlayer : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	void Start () {
		player=GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag=="Player"){
			player.GetComponent<PlayerUpgradeManager>().availableUpgrades.Add(gameObject);
			transform.position=new Vector3(0,100f,0f);
			Destroy(GetComponent<Rigidbody>());
		}
	}

}
