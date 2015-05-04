using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Exit ran.");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		Debug.Log("Something entered");
		if(col.gameObject.tag == "Player"){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}