using UnityEngine;
using System.Collections;

public class PlayerStateControls : MonoBehaviour {

	// Use this for initialization
	public Vector3 playerStartPos=Vector3.zero;
	public GameObject mapMaker;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Kill(){
		Destroy(gameObject);
	}

	public void MoveToLevel(){
		Instantiate(mapMaker,Vector3.zero,Quaternion.identity);
		transform.position=playerStartPos;
	}
}
