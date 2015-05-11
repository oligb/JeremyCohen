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

			gameObject.GetComponent<Tooltip>().statName = actualUpgradeObject.GetComponent<UpgradeStats>().types.ToString();
			transform.localScale = initScale * scaleFactor;

			if(actualUpgradeObject.GetComponent<UpgradeStats>().shotDamageBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().shotDamageBonus;

			} else if(actualUpgradeObject.GetComponent<UpgradeStats>().moveSpeedBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().moveSpeedBonus;

			}else if(actualUpgradeObject.GetComponent<UpgradeStats>().shotArcBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().shotArcBonus;

			}else if(actualUpgradeObject.GetComponent<UpgradeStats>().shotRangeBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().shotRangeBonus;

			}else if(actualUpgradeObject.GetComponent<UpgradeStats>().shotSpeedBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().shotSpeedBonus;

			}else if(actualUpgradeObject.GetComponent<UpgradeStats>().numPickupsBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().numPickupsBonus;

			}else if(actualUpgradeObject.GetComponent<UpgradeStats>().numShotsBonus != 0){
				gameObject.GetComponent<Tooltip>().statValue = actualUpgradeObject.GetComponent<UpgradeStats>().numShotsBonus;
			}

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
		player.GetComponent<PlayerAttacks>().PlayBeepSound();
		upgradeHighlightChild.enabled=true;
		playerUpgrades.currentUpgrades.Add(actualUpgradeObject);
		playerUpgrades.usedUpgradePoints+= actualUpgradeObject.GetComponent<UpgradeStats>().upgradeCost;
		playerUpgrades.UpdateTheStats();
	}
	public void Disable(){
		upgradeHighlightChild.enabled=false;
		player.GetComponent<PlayerAttacks>().PlayBoopSound();
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
						player.GetComponent<PlayerAttacks>().PlayShakeSound();
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
