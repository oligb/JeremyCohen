﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMakerV6 : MonoBehaviour {
	
	// A list for the gameObjects to reside so that the convex hull can be checked.
	public List<GameObject> convexHullList = new List<GameObject>();
	
	// The game object variables.
	public GameObject floortile, walltile, outerWall, spawner;
	public GameObject LWall, TripletWall, SquareWall;
	
	List<GameObject> wallTilesList = new List<GameObject>();
	
	bool hullChecked = false;
	
	// The tuning knobs.
	public int maxPathLength = 15;
	public int maximumPathCount = 3;
	public float pathmakerChance = 0.01f;
	public float wallMakerChance = 0.1f;
	public int maxXTiles,minXTiles,maxYTiles,minYTiles;
	public float enemySpawnChance = .05f;
	public int maxEnemiesSpawned = 25;
	public GameObject exit;
	public GameObject punchingBag;
	// float to check what to instanciate
	float randomNumber;
	
	public int roomNumber = 0;
	
	int previousDirection;
	
	// to controll the size of the maze.
	int currentPathLength,	 currentPathCount = 0;
	
	// the constraints for the blocks themselves
	int tileSize = 5;
	int enemyCount = 0;
	float rightTurnChance = 0f;
	
	//positions
	Vector3 activePathSpawnPosition, activeGridSpawnPosition;
	bool exitSpawned, turnBlock = false;
	bool initPath = true;
	
	
	
	// Use this for initialization
	void Start () {
		
		wallTilesList.Add(walltile);
		wallTilesList.Add(TripletWall);
		wallTilesList.Add(LWall);
		wallTilesList.Add(SquareWall);
		
		bool startedPath = false;
		bool onNorth = false; 
		bool onSouth = false;
		bool onEast = false;
		bool onWest = false;
		bool onBorder = false;
		
		//This chunk is very similar to the grid maker, it creates the starting grid.
		GameObject currentObject;
		
		// I wanted the rooms to have varied sizes.
		int verticalTileCount =  5;
		int horizontalTileCount = 5;
		
		// We are using the grid/ path instanciator.
		for (int x = 0; x < horizontalTileCount; x++){
			for ( int z = 0; z < verticalTileCount; z++){
				
				
				if (x == 0){onWest = true;}
				if (x == horizontalTileCount){onEast = true;}
				if (z == 0){onSouth = true;}
				if (z == verticalTileCount){onNorth = true;}
				
				if(onNorth || onSouth || onWest || onEast){
					onBorder = true;
				}
				
				
				bool notInCorner;
				
				if ( x > 4 && x < verticalTileCount - 3 &&
				    z > 4 && z < horizontalTileCount - 3 ){
					notInCorner = true;
				}else{
					notInCorner = false;
				}
				Vector3 position = new Vector3(x * tileSize, 0, z * tileSize) + gameObject.transform.position;
				randomNumber = Random.value;
				
				if (randomNumber < 1.0f - wallMakerChance){
					currentObject = Instantiate(floortile, position, gameObject.transform.rotation) as GameObject;
					convexHullList.Add(currentObject);
					
					if ( onBorder && !startedPath && (randomNumber < pathmakerChance) && (currentPathCount < maximumPathCount)){
						startedPath = true;
						activePathSpawnPosition = position;
						if(onNorth){
							previousDirection = 0;
							pathMaker (activePathSpawnPosition, previousDirection);
						}
						if(onSouth){
							previousDirection = 2;
							pathMaker (activePathSpawnPosition, previousDirection);
						}
						if(onNorth){
							previousDirection = 1;
							pathMaker (activePathSpawnPosition, previousDirection);
						}
						if(onNorth){
							previousDirection = 3;
							pathMaker (activePathSpawnPosition, previousDirection);
						}
						currentPathCount++;
					}
					
				} else if (notInCorner && randomNumber < 1f){
					currentObject = Instantiate(floortile, position, gameObject.transform.rotation) as GameObject;
					convexHullList.Add(currentObject);
				} else {
					//currentObject = Instantiate(walltile, position, gameObject.transform.rotation) as GameObject;
					//convexHullList.Add(currentObject);
				}
			}
		}
	}
	
	
	// The mostly same path spawner.
	void pathMaker(Vector3 spawnPathPos, int pathDirection){
		maxPathLength = Random.Range(maxPathLength, maxPathLength + 10);
		currentPathLength = 0;
		if ( initPath){
			currentPathLength = maxPathLength - 15;
			initPath = false;
		}
		
		GameObject currentObject;
		Vector3 spawnerPosition = spawnPathPos;
		GameObject tracer = Instantiate(spawner, spawnerPosition, Quaternion.Euler(0,90 * pathDirection,0) ) as GameObject;
		while (currentPathLength < maxPathLength){
			randomNumber = Random.value;
			
			currentObject = Instantiate(floortile, tracer.transform.position, tracer.transform.rotation) as GameObject;
			convexHullList.Add(currentObject);
			currentObject = Instantiate(floortile, tracer.transform.position + new Vector3(5,0,0), tracer.transform.rotation) as GameObject;
			convexHullList.Add(currentObject);
			currentObject = Instantiate(floortile, tracer.transform.position + new Vector3(0,0,5), tracer.transform.rotation) as GameObject;
			convexHullList.Add(currentObject);
			currentPathLength++;
			
			//turn block ensures the paths dont crash onthemselves.
			if (randomNumber < 0.5f && turnBlock){
				turnBlock = !turnBlock;
				rightTurnChance -= 0.005f;
				tracer.transform.Rotate(0,90,0);
				
			} else if ( randomNumber < 1f && !turnBlock ){
				turnBlock = !turnBlock;
				rightTurnChance += 0.005f;
				tracer.transform.Rotate(0,-90,0);
			} 
			tracer.transform.Translate(Vector3.forward * tileSize );
		} 
		gridMaker(tracer.transform.position);
	}
	
	
	void gridMaker(Vector3 spawnGridPos){
		bool startedPath = false;
		bool onNorth = false; 
		bool onSouth = false;
		bool onEast = false;
		bool onWest = false;
		bool onBorder = false;
		int pathDirection = 5;
		int randomDirectionNumber;
		List<int> pathDirectionList = new List<int>();;
		
		int verticalTileCount =  Random.Range(minYTiles,maxYTiles);
		int horizontalTileCount = Random.Range(minXTiles,maxXTiles);
		Vector3 position = Vector3.zero;
		
		Vector3 spawnerPosition = spawnGridPos;
		
		for (int x = 0; x < verticalTileCount; x++){
			for ( int z = 0; z < horizontalTileCount; z++){
				GameObject currentObject;
				
				if (x == 0){onWest = true;}
				if (x == horizontalTileCount){onEast = true;}
				if (z == 0){onSouth = true;}
				if (z == verticalTileCount){onNorth = true;}
				
				if(onNorth || onSouth || onWest || onEast){
					onBorder = true;
				}
				
				position = new Vector3(x * tileSize, 0, z * tileSize) + spawnerPosition;
				randomNumber = Random.value;
				
				bool notInCorner;
				if ( x > 4 && x < verticalTileCount - 3 &&
				    z > 4 && z < horizontalTileCount - 3) {
					notInCorner = true;
				}else{
					notInCorner = false;
				}
				
				if (randomNumber < 1.0f - wallMakerChance){
					currentObject = Instantiate(floortile, position, Quaternion.Euler(0f,0f,0f)) as GameObject;
					convexHullList.Add(currentObject);
					
					if ( onBorder && !notInCorner && !startedPath && (randomNumber < pathmakerChance) && (currentPathCount < maximumPathCount)){
						startedPath = true;
						activePathSpawnPosition = position;
						currentPathCount++;
						switch(previousDirection){
						case(0):
							randomDirectionNumber = Random.Range(0,3);
							pathDirectionList.Add(0);
							pathDirectionList.Add(1);
							pathDirectionList.Add(3);
							pathDirection = pathDirectionList[randomDirectionNumber];
							break;
						case(1):
							randomDirectionNumber = Random.Range(0,3);
							pathDirectionList.Add(0);
							pathDirectionList.Add(1);
							pathDirectionList.Add(2);
							pathDirection = pathDirectionList[randomDirectionNumber];
							break;
						case(2):
							randomDirectionNumber = Random.Range(0,3);
							pathDirectionList.Add(1);
							pathDirectionList.Add(2);
							pathDirectionList.Add(3);
							pathDirection = pathDirectionList[randomDirectionNumber];
							break;
						case(3):
							randomDirectionNumber = Random.Range(0,3);
							pathDirectionList.Add(0);
							pathDirectionList.Add(2);
							pathDirectionList.Add(3);
							pathDirection = pathDirectionList[randomDirectionNumber];
							break;
						}
						
						pathMaker (activePathSpawnPosition, pathDirection);
					}
					
					if(randomNumber < enemySpawnChance){
						if ( enemyCount < maxEnemiesSpawned ) {
							GameObject enemyTest = Instantiate(punchingBag,position,Quaternion.identity) as GameObject;
							enemyTest.transform.Translate(Vector3.up*2);
							enemyCount += 1;
						}
					}
				}else if (notInCorner && randomNumber < 1f){
					currentObject = Instantiate(floortile, position, gameObject.transform.rotation) as GameObject;
					currentObject = Instantiate(wallTilesList[Random.Range(0,wallTilesList.Count)], position, Quaternion.Euler(0,90 * Random.Range(0,3),0) ) as GameObject;
					convexHullList.Add(currentObject);
				} else {
					currentObject = Instantiate(walltile, position, gameObject.transform.rotation) as GameObject;
					convexHullList.Add(currentObject);
				}
				
				if ( roomNumber == 0 && randomNumber < .2f && !exitSpawned){
					//	Debug.Log("Exit instanciate should run.");
					Instantiate(exit, position, Quaternion.identity);
					exitSpawned = true;
				}
			}
		}
		
		
		roomNumber++;
		
	}
	
	// Check the nearby space of every object, if nothing exists create them walls!
	void hullCheck(){
		
		foreach  ( GameObject element in convexHullList){
			Collider[] hitColliders;
			
			hitColliders = Physics.OverlapSphere(element.transform.position + new Vector3(0f,0f,tileSize), 2f);
			if (hitColliders.Length == 0){
				Instantiate(outerWall, element.transform.position + new Vector3(0f,0f,tileSize), transform.rotation);
			}
			
			hitColliders = Physics.OverlapSphere(element.transform.position + new Vector3(0f,0f,-tileSize), 2f);
			if (hitColliders.Length == 0){
				Instantiate(outerWall, element.transform.position + new Vector3(0f,0f,-tileSize), transform.rotation);
			}
			
			hitColliders = Physics.OverlapSphere(element.transform.position + new Vector3(tileSize,0f,0f), 2f);
			if (hitColliders.Length == 0){
				Instantiate(outerWall, element.transform.position + new Vector3(tileSize,0f,0f), transform.rotation);
			}
			
			hitColliders = Physics.OverlapSphere(element.transform.position + new Vector3(-tileSize,0f,0f), 2f);
			if (hitColliders.Length == 0){
				Instantiate(outerWall, element.transform.position + new Vector3(-tileSize,0f,0f), transform.rotation);
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if ( !hullChecked && currentPathCount >= maximumPathCount){
			hullCheck();
			hullChecked = true;
		}
	}	
	
}

