using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {

	// Use this for initialization
	public Vector3 mousePos;
	public Vector3 startPos;
	public float scaleInput;
	public GameObject player;
	public bool canMoveCam=true;
	public float lerpAmt=.1f;
	public float distFromCenter;
	void Start () {
		player=GameObject.FindWithTag("Player");
		startPos=transform.localPosition;
		StartCoroutine("MoveCam");
	}
	
	// Update is called once per frame
	IEnumerator MoveCam () {
		while(true){
		if(canMoveCam){
		mousePos=Input.mousePosition;
		mousePos.x=mousePos.x-Screen.width/2f;
		mousePos.z=mousePos.y-Screen.height/2f;

				distFromCenter=Vector3.Distance(mousePos,startPos);

		mousePos.y=startPos.y;

				Vector3 camPos=mousePos*scaleInput/distFromCenter;
				camPos.y=startPos.y;

		transform.localPosition=Vector3.Lerp (transform.localPosition,camPos,lerpAmt);
        
				/*
		//transform.localPosition+=mousePos
				Vector3 movement= new Vector3();
				float speed = 0.003f; // bigger means faster
						movement.x += mousePos.x -transform.localPosition.x * speed;
						movement.z += mousePos.z -transform.localPosition.z * speed;
						movement.y=startPos.y;
				transform.localPosition=movement;
				*/
		}
			yield return 0;
	}
	}
}
