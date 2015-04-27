using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickableUpgrades : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public PlayerUpgradeManager playerUpgrades;

	public MeshRenderer upgradeHighlightChild;
	public bool onMenu=false;
	public bool upgradeEnabled=false;
	public float scaleFactor=1.2f;

	void Start () {

		player=GameObject.Find("Player");
		playerUpgrades=player.gameObject.GetComponent<PlayerUpgradeManager>();
		upgradeHighlightChild=transform.GetChild(0).GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(player.GetComponent<WorkbenchTrigger>().onMenu){
			onMenu=true;
		}
		else{
			onMenu=false;
		}
	}

	void Enable(){
		upgradeHighlightChild.enabled=true;
		playerUpgrades.currentUpgrades.Add(gameObject);
		playerUpgrades.UpdateTheStats();
	}
	void Disable(){
		upgradeHighlightChild.enabled=false;
		playerUpgrades.currentUpgrades.Remove(gameObject);
		playerUpgrades.UpdateTheStats();
	}


	void OnMouseEnter(){
		if(onMenu){
			transform.localScale*=scaleFactor;
		}
	}
	void OnMouseOver(){
			if( Input.GetMouseButtonDown(0) &&onMenu){
			if(!upgradeEnabled){
				upgradeEnabled=true;
				Enable ();
				}

			else{
				upgradeEnabled=false;
				Disable();
				}
			
		}
	}
	void OnMouseExit(){
		if(onMenu){
			transform.localScale/=scaleFactor;
	}
}
}
