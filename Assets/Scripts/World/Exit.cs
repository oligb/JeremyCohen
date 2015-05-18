using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public GameObject mapMaker, levelManager;
	public SfxrSynth teleportSynth;
	public GameObject tutorialText;

	// Use this for initialization
	void Start () {
		tutorialText=GameObject.Find ("tutorialtext");
		mapMaker = GameObject.Find("MapMakerV7(Clone)");
		levelManager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){


		if(col.gameObject.tag == "Player"){
			if(tutorialText!=null){
				Destroy(tutorialText.gameObject);
			}
			levelManager.GetComponent<LevelManager>().level++;
			levelManager.GetComponent<LevelManager>().IncreaseDifficulty();

			col.gameObject.GetComponent<PlayerStateControls>().MoveToPrepRoom();
			mapMaker.GetComponent<MapMakerV7>().DestroyTheWorld();
			Destroy(mapMaker);
			TeleportSound();
		}
	}
	
	public void TeleportSound(){
		teleportSynth = new SfxrSynth();
		teleportSynth.parameters.SetSettingsString(",.242,,.1244,,.0937,.3,.195,,,,,,,,,,,,,.5195,,,,,1,,,.1,,,");
		teleportSynth.Play();
		
	}
}