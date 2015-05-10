using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyDrops : MonoBehaviour {

	// Use this for initialization
	public GameObject barRefillParticle;
	public int energyRestored=5;
	public GameObject dropManager;
	public float randomUpgradeDropRate;
	public float upgradePointDropRate;
	public GameObject upgradePoint;
	public List<GameObject> possibleUpgrades=new List<GameObject>();
	void Start () {
		dropManager=GameObject.Find("DropManager");
		randomUpgradeDropRate=dropManager.GetComponent<DropManager>().randomEnemyDropRate;
		upgradePointDropRate=dropManager.GetComponent<DropManager>().upgradePointDropRate;
		possibleUpgrades=dropManager.GetComponent<DropManager>().possibleDropBag;
		energyRestored=dropManager.GetComponent<DropManager>().numPickupsPerEnemy;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DropStuff(){

		for(int i=1;i<energyRestored+1; i++){
			GameObject cube= Instantiate (barRefillParticle,transform.position,Quaternion.identity) as GameObject;
			cube.transform.Rotate(0f,i*360/energyRestored,0f);
			cube.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*300f);
		}

		float upgradePointRando=Random.Range (0f,1f);
		if(upgradePointRando<=upgradePointDropRate){
			Instantiate(upgradePoint,transform.position,Quaternion.identity);
		}
		else{
		float dropRando=Random.Range (0f,1f);
		if(dropRando<=randomUpgradeDropRate){
		int rando= Random.Range(0,possibleUpgrades.Count);
		Instantiate(possibleUpgrades[rando],transform.position,Quaternion.identity);
			}
		}

	}
}
