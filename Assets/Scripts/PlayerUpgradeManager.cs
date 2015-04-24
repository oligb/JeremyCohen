using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerUpgradeManager : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> availableUpgrades = new List<GameObject>();

	public List<GameObject> currentUpgrades = new List<GameObject>();

	public GameObject testUpgrade;

	public int playerLevel=1;
	public int pointsPerLevel=5;

	public float startShotDamage,startShotArc,startShotRange,startShotSpeed,startMoveSpeed,startBarSize,startShotVamp;
	public int startNumShots;
	private float currentShotDamage,currentShotArc,currentShotRange,currentShotSpeed,currentMoveSpeed,currentBarSize,currentShotVamp;
	private int currentNumShots;
	void Start () {

		currentMoveSpeed=startMoveSpeed;
		currentNumShots=startNumShots;
		currentShotDamage=startShotDamage;
		currentShotSpeed=startShotSpeed;
		currentShotArc=startShotArc;
		currentShotVamp=startShotVamp;
		currentShotRange=startShotRange;
		currentBarSize=startBarSize;


		SetTheStats();
	}
	
	// Update is called once per frame
	void Update () {
	/*
		if(Input.anyKeyDown){
			UpdateTheStats();
			SetTheStats();
		}
*/
		
		if(Input.GetKeyDown(KeyCode.U)){
		//	Instantiate(testUpgrade
		}

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
		int tempNumShots=0; 
		foreach(GameObject upgrade in currentUpgrades){
			UpgradeStats stats= upgrade.GetComponent<UpgradeStats>();
			tempMoveSpeed+=stats.moveSpeedBonus;
			tempNumShots+=stats.numShotsBonus;
			tempShotDamage+=stats.shotDamageBonus;
			tempShotSpeed+=stats.shotSpeedBonus;
			tempShotArc+=stats.shotArcBonus;
			tempShotVamp+=stats.shotVampBonus;
			tempShotRange+=stats.shotRangeBonus;
			tempBarSize+=stats.barSizeBonus;
		}

		currentMoveSpeed=tempMoveSpeed+startMoveSpeed;
		currentNumShots=tempNumShots+startNumShots;
		currentShotDamage=tempShotDamage+startShotDamage;
		currentShotSpeed=tempShotSpeed+startShotSpeed;
		currentShotArc=tempShotArc+startShotArc;
		currentShotVamp=tempShotVamp+startShotVamp;
		currentShotRange=tempShotRange+startShotRange;
		currentBarSize=tempBarSize+startBarSize;
	}



	//on exit the workbench set the stats

	public void SetTheStats(){
		Debug.Log("setstats");
		GetComponent<PlayerController>().moveSpeed=currentMoveSpeed;
		GetComponent<PlayerAttacks>().numShots=currentNumShots;
		GetComponent<PlayerAttacks>().bulletDamage=currentShotDamage;
		GetComponent<PlayerAttacks>().bulletSpeed=currentShotSpeed;
		GetComponent<PlayerAttacks>().shotArc=currentShotArc;
		GetComponent<PlayerAttacks>().shotVamp=currentShotVamp;
		GetComponent<PlayerAttacks>().maxRange=currentShotRange;
		GetComponent<PlayerMoveQueueing>().maxEnergy=currentBarSize;
		GetComponent<PlayerMoveQueueing>().currentEnergy=currentBarSize;
	}
}
