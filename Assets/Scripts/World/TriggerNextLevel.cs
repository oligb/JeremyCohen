using UnityEngine;
using System.Collections;

public class TriggerNextLevel : MonoBehaviour {

	// Use this for initialization
	SfxrSynth teleportSynth;

	void Start(){
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag=="Player" && !col.gameObject.GetComponent<PlayerMoveQueueing>().timeStopped){
		col.GetComponent<PlayerStateControls>().MoveToLevel();
			TeleportSound();
		}
	}

	public void TeleportSound(){
		teleportSynth = new SfxrSynth();
		teleportSynth.parameters.SetSettingsString("4,.5,.0452,.6048,.1281,.9085,.9188,.5347,,.0377,.0363,-.0381,-.18,.7448,.7864,.9618,.8507,-.3596,-.8709,.7911,.8067,-.0005,.4318,.0004,,.9942,.0043,.9161,.0006,-.0002,.4298,.7089");
		teleportSynth.Play();
		
	}

}
