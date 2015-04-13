using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	// Use this for initialization
	public float startTime=0f;
	public float lifeTime=5f;
	void Start () {
		startTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Time.time-startTime>lifeTime){
			Destroy(gameObject);
	}
	}
}
