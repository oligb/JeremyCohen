using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowWorkbenchUpgrades : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> availableUpgrades= new List<GameObject>();
	public List<GameObject> currentUpgrades= new List<GameObject>();
	public PlayerUpgradeManager manager;

	public float margins=.1f;
	public GameObject upgradePlaceholder;
	public float upgradeScale=.03f;
	void Start () {
		manager=GameObject.Find("Player").GetComponent<PlayerUpgradeManager>();
	}


	public void ShowUpgrades(){

		int current=0;
		availableUpgrades = manager.availableUpgrades;
		currentUpgrades=manager.currentUpgrades;
		int numUpgrades=availableUpgrades.Count;
		Debug.Log(availableUpgrades);
		if(numUpgrades<20){
			margins=.1f;
		}

		for(float i=.4f; i>=-.4f; i-=margins){
					for(float j=.4f; j>=-.3f; j-=margins){
				if(current<numUpgrades){
					GameObject upgradeTile=Instantiate(upgradePlaceholder,Vector3.zero,Quaternion.Euler(0f,90f,0f)) as GameObject;
					upgradeTile.transform.SetParent(gameObject.transform);
					upgradeTile.transform.localPosition=new Vector3(j,i,.5f);
					upgradeTile.transform.localScale=new Vector3(.03f,upgradeScale,upgradeScale);

					upgradeTile.GetComponent<ClickableUpgrades>().actualUpgradeObject=availableUpgrades[current];
					upgradeTile.GetComponent<ClickableUpgrades>().SetTextureFromUpgrade();

					foreach(GameObject enabledUpgrade in currentUpgrades){
						if(enabledUpgrade==availableUpgrades[current]){
							upgradeTile.GetComponent<ClickableUpgrades>().upgradeEnabled=true;
							upgradeTile.GetComponent<ClickableUpgrades>().upgradeHighlightChild.enabled=true;
						}
					}
				   current++;
				}
			}
		}
	
	}

	public void DestroyUpgrades(){
		foreach (Transform child in transform){
			Destroy(child.gameObject);
		}
	}

	void Update () {
	
	}
}
