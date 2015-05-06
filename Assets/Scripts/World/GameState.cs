using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	// Use this for initialization
	public static GameState instance;
	public bool timeStopped=false;

	void Awake(){
		instance=this;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
