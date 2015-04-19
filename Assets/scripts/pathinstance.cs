using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathinstance : MonoBehaviour {

	// A list for the gameObjects to reside so that the convex hull can be checked.
	List<GameObject> convexHullList = new List<GameObject>();

	// The game object variables.
	public GameObject floortile, walltile, outerWall, spawner;

	// The tuning knobs.
	public int maxPathLength = 15;
	public int maximumPathCount = 3;
	public float pathmakerChance = 0.01f;
	public float wallMakerChance = 0.1f;

	// float to check what to instanciate
	float randomNumber;

	// to controll the size of the maze.
	int currentPathLength;
	int currentPathCount = 0;

	// the constraints for the blocks themselves
	int tileSize = 5;
	int verticalTileCount, horizontalTileCount;

	float rightTurnChance = 0f;

	//positions
	Vector3 activePathSpawnPosition, activeGridSpawnPosition;
	bool turnBlock = false;

	// Use this for initialization
	void Start () {

		//This chunk is very similar to the grid maker, it creates the starting grid.
		GameObject currentObject;

		 // I wanted the rooms to have varied sizes.
		verticalTileCount =  Random.Range(4,8);
		horizontalTileCount = Random.Range(4,8);

		// We are using the grid/ path instanciator.
		for (int x = 0; x < verticalTileCount; x++){
			for ( int z = 0; z < horizontalTileCount; z++){
				
				Vector3 position = new Vector3(x * tileSize, 0, z * tileSize) + gameObject.transform.position;
				randomNumber = Random.value;
				
				if (randomNumber < 1.0f - wallMakerChance){
					currentObject = Instantiate(floortile, position, gameObject.transform.rotation) as GameObject;
					convexHullList.Add(currentObject);

					if (randomNumber < pathmakerChance && currentPathCount < maximumPathCount){
						activePathSpawnPosition = position;
						pathMaker (activePathSpawnPosition);
						currentPathCount++;
					}
					
				} else if (randomNumber < 1f){
					currentObject = Instantiate(walltile, position, gameObject.transform.rotation) as GameObject;
					convexHullList.Add(currentObject);
				}
			}
		}
	}


	// The mostly same path spawner.
	void pathMaker(Vector3 spawnPathPos){
		currentPathLength = 0;
		GameObject currentObject;
		Vector3 spawnerPosition = spawnPathPos;
		GameObject tracer = Instantiate(spawner, spawnerPosition, gameObject.transform.rotation) as GameObject;
		while (currentPathLength < maxPathLength){
			randomNumber = Random.value;
			
			currentObject = Instantiate(floortile, tracer.transform.position, tracer.transform.rotation) as GameObject;
			convexHullList.Add(currentObject);
			currentPathLength++;

			//turn block ensures the paths dont crash onthemselves.

			if (randomNumber + rightTurnChance < 0.5f ){
				rightTurnChance -= 0.005f;
				tracer.transform.Rotate(0,90,0);
			} else if ( randomNumber < 1f ){
				rightTurnChance += 0.005f;
				tracer.transform.Rotate(0,-90,0);
			} 
			tracer.transform.Translate(Vector3.forward * tileSize );
		} 
		gridMaker(tracer.transform.position);
	}

	
	void gridMaker(Vector3 spawnGridPos){
		Vector3 spawnerPosition = spawnGridPos;
		for (int x = 0; x < verticalTileCount; x++){
			for ( int z = 0; z < horizontalTileCount; z++){
				GameObject currentObject;

				Vector3 position = new Vector3(x * tileSize, 0, z * tileSize) + spawnerPosition;
				randomNumber = Random.value;
				
				if (randomNumber < 1.0f - wallMakerChance){
					currentObject = Instantiate(floortile, position, Quaternion.Euler(0f,0f,0f)) as GameObject;
					convexHullList.Add(currentObject);

				} else {
					currentObject = Instantiate(walltile, position, Quaternion.Euler(0f,0f,0f)) as GameObject;
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

		if (currentPathCount == maximumPathCount){
			hullCheck();
		}
	}	

}

