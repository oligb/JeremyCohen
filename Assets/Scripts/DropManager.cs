﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DropManager : MonoBehaviour {

	public float randomEnemyDropRate=.05f;
	public List<GameObject> possibleDropBag=new List<GameObject>();
	public int numPickupsPerEnemy;

	public int totalUpgradesForThisLevel;
	public float upgradePointDropRate=.25f;
	public GameObject upgradePoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void NewLevel(){


	}


}
