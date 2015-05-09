using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject mapMaker;
	// Use this for initialization
	void Start () {
		mapMaker = GameObject.Find("MapMakerV7(Clone)");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.GetComponent<PlayerStateControls>().MoveToPrepRoom();
			mapMaker.GetComponent<MapMakerV7>().DestroyTheWorld();

		}
	}
}