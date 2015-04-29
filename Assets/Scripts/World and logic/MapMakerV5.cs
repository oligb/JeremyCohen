using UnityEngine;
using System.Collections;
using System.Collections.Generic;

	
	public class MapMakerV5 : MonoBehaviour {
		
		// A list for the gameObjects to reside so that the convex hull can be checked.
		public List<GameObject> convexHullList = new List<GameObject>();
		
		// The game object variables.
		public GameObject floortile, walltile, outerWall, spawner;
		public GameObject LWall, TripletWall, SquareWall;
		
		List<GameObject> wallTilesList = new List<GameObject>();
		
		// The tuning knobs.
		public int maxPathLength = 15;
		public int maximumPathCount = 3;
		public float pathmakerChance = 0.01f;
		public float wallMakerChance = 0.1f;
		public int maxXTiles,minXTiles,maxYTiles,minYTiles;
		public float enemySpawnChance = .05f;
		public int enemyCount = 0;
		public int maxEnemiesSpawned = 25;
		
		public GameObject punchingBag;
		// float to check what to instanciate
		float randomNumber;
		
		// to controll the size of the maze.
		int currentPathLength,	 currentPathCount = 0;
		
		// the constraints for the blocks themselves
		int tileSize = 5;
		
		float rightTurnChance = 0f;
		
		//positions
		Vector3 activePathSpawnPosition, activeGridSpawnPosition;
		bool turnBlock = false;
		bool initPath = true;
		
		
		// Use this for initialization
		void Start () {
			bool startedPath = false;
			
			wallTilesList.Add(walltile);
			wallTilesList.Add(TripletWall);
			wallTilesList.Add(LWall);
			wallTilesList.Add(SquareWall);
			
			//This chunk is very similar to the grid maker, it creates the starting grid.
			GameObject currentObject;
			
			// I wanted the rooms to have varied sizes.
			int verticalTileCount =  Random.Range(minYTiles,maxYTiles);
			int horizontalTileCount = Random.Range(minXTiles,maxXTiles);
			
			// We are using the grid/ path instanciator.
			for (int x = 0; x < 5; x++){
				for ( int z = 0; z < 5; z++){
					
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
						
						if ( !notInCorner && !startedPath && (randomNumber < pathmakerChance) && (currentPathCount < maximumPathCount)){
							startedPath = true;
							activePathSpawnPosition = position;
							pathMaker (activePathSpawnPosition);
							currentPathCount++;
						}
						
					} else if (notInCorner && randomNumber < 1f){
						currentObject = Instantiate(floortile, position, gameObject.transform.rotation) as GameObject;
						//currentObject = Instantiate(wallTilesList[Random.Range(0,wallTilesList.Count)], position, Quaternion.Euler(0,90 * Random.Range(0,3),0) ) as GameObject;
						convexHullList.Add(currentObject);
					} else {
						currentObject = Instantiate(walltile, position, gameObject.transform.rotation) as GameObject;
						convexHullList.Add(currentObject);
					}
				}
			}
		}
		
		
		// The mostly same path spawner.
		void pathMaker(Vector3 spawnPathPos){
			
			currentPathLength = 0;
			if ( initPath){
				currentPathLength = maxPathLength - 10;
				initPath = false;
			}
			

			GameObject currentObject;
			Vector3 spawnerPosition = spawnPathPos;
			int direction = Random.Range(1,4);
			GameObject tracer = Instantiate(spawner, spawnerPosition, Quaternion.Euler(0,90 * direction,0) ) as GameObject;
			while (currentPathLength < maxPathLength){
				randomNumber = Random.value;
				
				currentObject = Instantiate(floortile, tracer.transform.position, tracer.transform.rotation) as GameObject;
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
			
			int verticalTileCount =  Random.Range(minYTiles,maxYTiles);
			int horizontalTileCount = Random.Range(minXTiles,maxXTiles);
			
			Vector3 spawnerPosition = spawnGridPos;
			bool startedPath = false;
			for (int x = 0; x < verticalTileCount; x++){
				for ( int z = 0; z < horizontalTileCount; z++){
					GameObject currentObject;
					
					Vector3 position = new Vector3(x * tileSize, 0, z * tileSize) + spawnerPosition;
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
						
					if ( !notInCorner &&  !startedPath && (randomNumber < pathmakerChance) && (currentPathCount < maximumPathCount)){
							startedPath = true;
							activePathSpawnPosition = position;
							currentPathCount++;
							pathMaker (activePathSpawnPosition);
							
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
				}
			}
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
			
			if (currentPathCount >= maximumPathCount){
				hullCheck();
			}
		}	
		
	
}