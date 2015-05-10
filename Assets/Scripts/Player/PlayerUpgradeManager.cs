using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerUpgradeManager : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> availableUpgrades = new List<GameObject>();

	public List<GameObject> currentUpgrades = new List<GameObject>();


	public int currentUpgradePoints=5;

	public float startShotDamage,startShotArc,startShotRange,startShotSpeed,startMoveSpeed,startBarSize;
	public int startNumShots,startNumPickups;

	public GameObject dropManager;
	float currentShotDamage,currentShotArc,currentShotRange,currentShotSpeed,currentMoveSpeed,currentBarSize;
	int currentNumShots,currentNumPickups;

	void Start () {
		dropManager=GameObject.Find("DropManager");

		currentMoveSpeed=startMoveSpeed;
		currentNumShots=startNumShots;
		currentShotDamage=startShotDamage;
		currentShotSpeed=startShotSpeed;
		currentShotArc=startShotArc;
		currentShotRange=startShotRange;
		currentBarSize=startBarSize;
		currentNumPickups=startNumPickups;


		SetTheStats();
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void UpdateTheStats(){
		Debug.Log("updatestats");
		float tempShotDamage=0f;
		float tempShotArc=0f;
		float tempShotRange=0f;
		float tempShotSpeed=0f;
		float tempMoveSpeed=0f;
		float tempBarSize=0f;
		float tempShotVamp=0f;
		int tempNumPickups=0;
		int tempNumShots=0; 
		foreach(GameObject upgrade in currentUpgrades){
			UpgradeStats stats= upgrade.GetComponent<UpgradeStats>();
			tempMoveSpeed+=stats.moveSpeedBonus;
			tempShotDamage+=stats.shotDamageBonus;
			tempShotSpeed+=stats.shotSpeedBonus;
			tempShotArc+=stats.shotArcBonus;
			tempShotRange+=stats.shotRangeBonus;
			tempBarSize+=stats.barSizeBonus;
			tempNumShots+=stats.numShotsBonus;
			tempNumPickups+=stats.numPickupsBonus;
		}

		currentMoveSpeed=tempMoveSpeed+startMoveSpeed;
		currentShotDamage=tempShotDamage+startShotDamage;
		currentShotSpeed=tempShotSpeed+startShotSpeed;
		currentShotArc=tempShotArc+startShotArc;
		currentShotRange=tempShotRange+startShotRange;
		currentBarSize=tempBarSize+startBarSize;
		currentNumShots=tempNumShots+startNumShots;
		currentNumPickups=tempNumPickups+startNumPickups;
	}



	//on exit the workbench set the stats

	public void SetTheStats(){
		Debug.Log("setstats");
		GetComponent<PlayerController>().maxSpeed=currentMoveSpeed;
		GetComponent<PlayerAttacks>().numShots=currentNumShots;
		GetComponent<PlayerAttacks>().bulletDamage=currentShotDamage;
		GetComponent<PlayerAttacks>().bulletSpeed=currentShotSpeed;
		GetComponent<PlayerAttacks>().shotArc=currentShotArc;
		GetComponent<PlayerAttacks>().maxRange=currentShotRange;
		GetComponent<PlayerMoveQueueing>().maxEnergy=currentBarSize;
		GetComponent<PlayerMoveQueueing>().currentEnergy=currentBarSize;
		dropManager.GetComponent<DropManager>().numPickupsPerEnemy=currentNumPickups;
	}
}
