using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowWorkbenchUpgrades : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> availableUpgrades= new List<GameObject>();
	public PlayerUpgradeManager manager;

	void Start () {
		manager=GameObject.Find("Player").GetComponent<PlayerUpgradeManager>();
	}
	
	// Update is called once per frame

	void CalculateDimensions(){
		//int numUpgrades = manager.availableUpgrades.Count;
	}


	void Update () {
	
	}
}
