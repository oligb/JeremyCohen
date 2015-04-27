using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TemporaryWallSpawnFix : MonoBehaviour {

	// Use this for initialization
	public Vector3 startPos;
	void Start () {
		startPos=transform.position;
		startPos.y=0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionStay(Collision col){
		if(col.gameObject.name=="Wall(Clone)" &&Vector3.Distance(col.transform.position,startPos)<1f){
			Debug.Log("inWall");
			GameObject.Find("MapMaker").GetComponent<pathinstance>().convexHullList.Remove(col.gameObject);
			Destroy(col.gameObject);
		}
	}
}
