using UnityEngine;
using System.Collections;

public class OtherScreenShake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	IEnumerator ScreenShake(){
		float percent=1f;

		Vector3 cameraStartPos= Camera.main.transform.position;

		while(percent>0f){

		
			Vector3 cameraShakeOffset =Camera.main.transform.right*Mathf.Sin(Time.time*97f)+ Camera.main.transform.up*Mathf.Sin(Time.time*47f);
			Camera.main.transform.position=cameraStartPos + cameraShakeOffset * percent;
			yield return 0;
			percent-=Time.deltaTime;

		}
	}

}
