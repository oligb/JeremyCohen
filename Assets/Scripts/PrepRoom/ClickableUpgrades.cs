using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickableUpgrades : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject workbenchTrigger;
	public PlayerUpgradeManager playerUpgrades;

	public MeshRenderer upgradeHighlightChild;
	public bool onMenu=false;
	public bool upgradeEnabled=false;
	public float scaleFactor=1.2f;
	public bool mouseOver=false;
	Vector3 initScale;
	public GameObject actualUpgradeObject;
	public Texture upgradeTexture;

	void Start () {
		initScale=transform.localScale;
		workbenchTrigger=GameObject.Find("WorkbenchTrigger");
		player=GameObject.Find("Player");
		playerUpgrades=player.gameObject.GetComponent<PlayerUpgradeManager>();
		upgradeHighlightChild=transform.GetChild(0).GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {	
		if(workbenchTrigger.GetComponent<PlayerEnterTrigger>().onMenu){
			onMenu=true;
		}
		else{
			onMenu=false;
		}
		if(mouseOver){
		transform.localScale=initScale*scaleFactor;
		}
		else{
		transform.localScale=initScale;
		}
	}

	public void SetTextureFromUpgrade(){
		UpgradeType types=actualUpgradeObject.GetComponent<UpgradeStats>().types;
		switch(types){
		case UpgradeType.ShotDamage:
			upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().ShotDamage;
			break;
		case UpgradeType.MoveSpeed:
			upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().MoveSpeed;
			break;
		case UpgradeType.ShotArc:
			upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().ShotArc;
			break;
		case UpgradeType.ShotRange:
			upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().ShotRange;
			break;
		case UpgradeType.ShotSpeed:
			upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().ShotSpeed;
			break;
		case UpgradeType.NumShots:
			upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().NumShots;
			break;
		}
		
		GetComponent<MeshRenderer>().materials[0].SetTexture(0,upgradeTexture);
	}

	public void Enable(){
		upgradeHighlightChild.enabled=true;
		playerUpgrades.currentUpgrades.Add(actualUpgradeObject);

		playerUpgrades.UpdateTheStats();
	}
	public void Disable(){
		upgradeHighlightChild.enabled=false;
		playerUpgrades.currentUpgrades.Remove(actualUpgradeObject);
		playerUpgrades.UpdateTheStats();
	}

	
	void OnMouseOver(){	
		mouseOver=true;
		if(onMenu){
			if( Input.GetMouseButtonDown(0)){
			
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
	}
	void OnMouseExit(){
		mouseOver=false;
	}

}
