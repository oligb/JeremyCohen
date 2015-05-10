 using UnityEngine;
using System.Collections;

public class PlayerEnterTrigger : MonoBehaviour {
	
	public Vector3 startPosCam;
	public Vector3 targetPosCam;
	public Vector3 workbenchCamPos;
	public Vector3 consoleCamPos;
	public Quaternion startRotation;
	public Quaternion targetRotation;
	public float startFOV;
	public float endFOV;
	public float inLerpSpeed=.1f;
	public float outLerpSpeed=.5f;
	public Transform player;
	public bool onMenu=false;
	public bool lerping=false;
	public GameObject workbench;
	public GameObject stuffHolder;
	
	void Start(){
		workbench=GameObject.Find("Workbench");
		stuffHolder=GameObject.Find("StuffHolder");
		startRotation=Camera.main.transform.rotation;
		startPosCam=Camera.main.transform.localPosition;
		player=GameObject.Find("Player").transform;
	}
	void Update() {
		
	}
	
	
	void OnTriggerEnter(Collider col){
		if(!onMenu && !lerping &&col.tag=="Player" && !player.GetComponent<PlayerMoveQueueing>().timeStopped){
			lerping=true;
			StartCoroutine("ZoomIn");

		}
	}	
	void OnTriggerExit(Collider col){
		if(onMenu && !lerping &&col.tag=="Player" && !player.GetComponent<PlayerMoveQueueing>().timeStopped){
			if(col.gameObject==player){
				targetPosCam=player.position;
			}
			
			lerping=true;
			StartCoroutine("ZoomOut");
		}
	}
	
	IEnumerator ZoomIn(){
		player.GetComponentInChildren<CamMovement>().canMoveCam=false;
		workbench.GetComponent<ShowWorkbenchUpgrades>().ShowUpgrades();
		player.gameObject.GetComponent<PlayerController>().canMove=false;
		player.gameObject.GetComponent<PlayerController>().GetComponent<Rigidbody>().velocity*=.5f;

		stuffHolder.SetActive(false);
		float i=0f;
		while(i<=1f){
			Vector3 currentPos=Vector3.Lerp(startPosCam,targetPosCam,i);
			//Vector3 currentRot=Vector3.Lerp(startRotation,targetRotation,i);
			Quaternion currentRot=Quaternion.Slerp(startRotation,targetRotation,i);
			float currentFOV=Mathf.Lerp(startFOV,endFOV,i);
			
			Camera.main.gameObject.GetComponent<Camera>().fieldOfView=currentFOV;
			Camera.main.transform.localPosition=currentPos;
			Camera.main.transform.localRotation=currentRot;
			i+=inLerpSpeed;
			yield return 0;
		}
		lerping=false;
		onMenu=true;

		player.gameObject.GetComponent<PlayerController>().canMove=true;
		yield break;
	}
	
	IEnumerator ZoomOut(){

		stuffHolder.SetActive(true);

		float i=0f;
		while(i<=1f){
			Vector3 currentPos=Vector3.Lerp(targetPosCam,startPosCam,i);
			//Vector3 currentRot=Vector3.Lerp(targetRotation,startRotation,i);
			Quaternion currentRot=Quaternion.Slerp(targetRotation,startRotation,i);
			float currentFOV=Mathf.Lerp(endFOV,startFOV,i);
			
			Camera.main.gameObject.GetComponent<Camera>().fieldOfView=currentFOV;
			Camera.main.transform.localPosition=currentPos;
			Camera.main.transform.localRotation=currentRot;
			i+=outLerpSpeed;
			yield return 0;
		}
		Camera.main.gameObject.GetComponent<Camera>().fieldOfView=startFOV;
		Camera.main.transform.localPosition=startPosCam;
		Camera.main.transform.localRotation=startRotation;
		lerping=false;
		onMenu=false;
		workbench.GetComponent<ShowWorkbenchUpgrades>().DestroyUpgrades();
		player.gameObject.GetComponent<PlayerUpgradeManager>().SetTheStats();
		player.GetComponentInChildren<CamMovement>().canMoveCam=true;
		yield break;
	}
	
	
}
