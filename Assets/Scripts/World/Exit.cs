using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject mapMaker, levelManager;
	// Use this for initialization
	void Start () {
		mapMaker = GameObject.Find("MapMakerV7(Clone)");
		levelManager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){


		if(col.gameObject.tag == "Player"){
			levelManager.GetComponent<LevelManager>().level++;
			levelManager.GetComponent<LevelManager>().IncreaseDifficulty();

			col.gameObject.GetComponent<PlayerStateControls>().MoveToPrepRoom();
			mapMaker.GetComponent<MapMakerV7>().DestroyTheWorld();

		}
	}
}