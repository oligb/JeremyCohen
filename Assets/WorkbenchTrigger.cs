using UnityEngine;
using System.Collections;

public class WorkbenchTrigger : MonoBehaviour {
	
	public Vector3 startPosCam;
	public Vector3 targetPosCam;
	public Vector3 startRotation;
	public Vector3 targetRotation;
	public float startFOV;
	public float endFOV;
	public float inLerpSpeed=.1f;
	public float outLerpSpeed=.5f;
	public Transform player;
	public bool onMenu=false;
	public bool lerping=false;

	void Start(){
		startPosCam=Camera.main.transform.position;
		player=GameObject.Find("Player").transform;
	}
	void Update() {

	}

	
	void OnTriggerEnter(){
		if(!onMenu && !lerping){
			lerping=true;
			StartCoroutine("ZoomIn");
		}
	}	
	void OnTriggerExit(){
		if(onMenu && !lerping){
			lerping=true;
			StartCoroutine("ZoomOut");
		}
	}

	IEnumerator ZoomIn(){
		player.GetComponent<PlayerController>().canMove=false;
		player.GetComponent<PlayerController>().GetComponent<Rigidbody>().velocity*=.5f;
		float i=0f;
		while(i<1f){
			Vector3 currentPos=Vector3.Lerp(startPosCam,targetPosCam,i);
			Vector3 currentRot=Vector3.Lerp(startRotation,targetRotation,i);
			float currentFOV=Mathf.Lerp(startFOV,endFOV,i);

			Camera.main.gameObject.GetComponent<Camera>().fieldOfView=currentFOV;
			Camera.main.transform.position=currentPos;
			Camera.main.transform.rotation=Quaternion.Euler(currentRot);
			i+=inLerpSpeed;
			yield return 0;
		}
		lerping=false;
		onMenu=true;
		player.GetComponent<PlayerController>().canMove=true;
	}

	IEnumerator ZoomOut(){
		float i=0f;
		while(i<1f){
			Vector3 currentPos=Vector3.Lerp(targetPosCam,startPosCam,i);
			Vector3 currentRot=Vector3.Lerp(targetRotation,startRotation,i);
			float currentFOV=Mathf.Lerp(endFOV,startFOV,i);
			
			Camera.main.gameObject.GetComponent<Camera>().fieldOfView=currentFOV;
			Camera.main.transform.position=currentPos;
			Camera.main.transform.rotation=Quaternion.Euler(currentRot);
			i+=outLerpSpeed;
			yield return 0;
		}
		Camera.main.gameObject.GetComponent<Camera>().fieldOfView=startFOV;
		Camera.main.transform.position=startPosCam;
		Camera.main.transform.rotation=Quaternion.Euler(startRotation);
		lerping=false;
		onMenu=false;
		player.GetComponent<PlayerUpgradeManager>().SetTheStats();
	}


}
