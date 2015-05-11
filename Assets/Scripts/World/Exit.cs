using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject mapMaker, levelManager;
	public SfxrSynth teleportSynth;

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

			TeleportSound();
		}
	}
	
	public void TeleportSound(){
		teleportSynth = new SfxrSynth();
		teleportSynth.parameters.SetSettingsString("4,.5,.0452,.6048,.1281,.9085,.9188,.5347,,.0377,.0363,-.0381,-.18,.7448,.7864,.9618,.8507,-.3596,-.8709,.7911,.8067,-.0005,.4318,.0004,,.9942,.0043,.9161,.0006,-.0002,.4298,.7089");
		teleportSynth.Play();
		
	}
}