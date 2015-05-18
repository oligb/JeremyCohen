using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class motionBlurController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
			if(!GetComponent<PlayerMoveQueueing>().timeStopped){
				Camera.main.GetComponent<CameraMotionBlur>().enabled=false;
			}			
			else{
				Camera.main.GetComponent<CameraMotionBlur>().enabled=true;
			}
	}
}
