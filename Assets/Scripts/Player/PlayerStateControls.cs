using UnityEngine;
using System.Collections;

public class PlayerStateControls : MonoBehaviour {

	// Use this for initialization
	public Vector3 playerLevelStartPos= new Vector3(0f,2f,0f);
	public Vector3 playerInitSpawnPoint;
	public GameObject mapMaker;

	void Start () {
		playerInitSpawnPoint=transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.U)){
			transform.position=playerInitSpawnPoint;
		}
	
	}
	public void Kill(){
		//transform.position=playerInitSpawnPoint;
		Application.LoadLevel("PrepRoom");
	}

	public void MoveToLevel(){
		Instantiate(mapMaker,Vector3.zero,Quaternion.identity);
		transform.position=playerLevelStartPos;
	}
	public void MoveToPrepRoom(){
		transform.position=playerInitSpawnPoint;
	}
}
