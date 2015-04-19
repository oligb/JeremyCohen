using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	// Use this for initialization
	public float startTime=0f;
	public float lifeTime=5f;
	public Vector3 startPos, endPos;
	public float range;
	void Start () {
		startTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(transform.position,startPos)>range){
			Destroy(gameObject);
		}
	
		if(Time.time-startTime>lifeTime){
			Destroy(gameObject);
	}
	}
}
