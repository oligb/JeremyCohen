using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickableUpgrades : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public GameObject workbenchTrigger;
	public PlayerUpgradeManager playerUpgrades;
	public float duration=.5f;
	public float magnitude=.1f;

	public MeshRenderer upgradeHighlightChild;
	public bool onMenu=false;
	public bool upgradeEnabled=false;
	public float scaleFactor=1.2f;
	public bool mouseOver=false;
	Vector3 initScale;
	public GameObject actualUpgradeObject;
	public Texture upgradeTexture;

	public int usedPoints;
	public int availablePoints;

	void Start () {
		initScale=transform.localScale;
		workbenchTrigger=GameObject.Find("WorkbenchTrigger");
		player=GameObject.Find("Player");
		playerUpgrades=player.gameObject.GetComponent<PlayerUpgradeManager>();
		upgradeHighlightChild=transform.GetChild(0).GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {	



		usedPoints=playerUpgrades.usedUpgradePoints;
		availablePoints=playerUpgrades.currentUpgradePoints;

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
		upgradeTexture=actualUpgradeObject.GetComponent<UpgradeStats>().upgradeTexture;
		GetComponent<MeshRenderer>().materials[0].SetTexture(0,upgradeTexture);
	}

	public void Enable(){

		upgradeHighlightChild.enabled=true;
		playerUpgrades.currentUpgrades.Add(actualUpgradeObject);
		playerUpgrades.usedUpgradePoints+= actualUpgradeObject.GetComponent<UpgradeStats>().upgradeCost;
		playerUpgrades.UpdateTheStats();
	}
	public void Disable(){
		upgradeHighlightChild.enabled=false;
		playerUpgrades.currentUpgrades.Remove(actualUpgradeObject);
		playerUpgrades.usedUpgradePoints-= actualUpgradeObject.GetComponent<UpgradeStats>().upgradeCost;
		playerUpgrades.UpdateTheStats();
	}


		IEnumerator ShakeUpgrade() {
			
			float elapsed = 0.0f;
			
			Vector3 originalCamPos = transform.localPosition;
			
			while (elapsed < duration) {
				
				elapsed += Time.deltaTime;          
				
				float percentComplete = elapsed / duration;         
				float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
				
				// map value to [-1, 1]
				float x = Random.value * 2.0f - 1.0f;
				float y = Random.value * 2.0f - 1.0f;
				x *= magnitude * damper;
				y *= magnitude * damper;
				
				transform.localPosition = new Vector3(originalCamPos.x+x, originalCamPos.y, originalCamPos.z);
				
				yield return null;
			}
			
			transform.localPosition = originalCamPos;
		}
	
	void OnMouseOver(){	
		mouseOver=true;
		if(onMenu){
			if( Input.GetMouseButtonDown(0) ){
			
				if(!upgradeEnabled){
					if(actualUpgradeObject.GetComponent<UpgradeStats>().upgradeCost+usedPoints<=availablePoints){
					upgradeEnabled=true;
					Enable ();
					}
					else{
						StartCoroutine("ShakeUpgrade");
					}

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
