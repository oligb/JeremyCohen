using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//initilize the variables;
	int melee1Difficulty, melee2Difficulty, melee3Difficulty;
	int ranged1Difficulty, ranged2Difficulty, ranged3Difficulty;

	// Defining the enemies. These game objects refer to the different types of enemies.
	public GameObject melee1 ,melee2, melee3;
	public GameObject ranged1, ranged2, ranged3;

	GameObject currentEnemy;
	
	// This int will be set for every specific room.
	public int roomDifficulty;
	int currentDifficulty;
	// Use this for initialization
	void Start () {

		melee1Difficulty = melee1.GetComponent<enemyDifficulty>().difficultyValue;
		melee2Difficulty = melee2.GetComponent<enemyDifficulty>().difficultyValue;
		melee3Difficulty = melee3.GetComponent<enemyDifficulty>().difficultyValue;

		ranged1Difficulty = ranged1.GetComponent<enemyDifficulty>().difficultyValue;
		ranged2Difficulty = ranged2.GetComponent<enemyDifficulty>().difficultyValue;
		ranged3Difficulty = ranged3.GetComponent<enemyDifficulty>().difficultyValue;

		StartCoroutine(SpawnerCoroutine());
	}


	IEnumerator SpawnerCoroutine(){



		while (currentDifficulty < roomDifficulty ){

			float random = Random.Range(0,6);
			if (  random < 1){
				currentEnemy = melee1;
				currentDifficulty += melee1Difficulty;

			} else if ( random < 2){
				currentEnemy = melee2;
				currentDifficulty += melee2Difficulty;

			}else if ( random < 3){
				currentEnemy = melee3;
				currentDifficulty += melee3Difficulty;

			}else if ( random < 4){
				currentEnemy = ranged1;
				currentDifficulty += ranged1Difficulty;

			}else if ( random < 5){
				currentEnemy = ranged2;
				currentDifficulty += ranged2Difficulty;

			}else if ( random < 6){
				currentEnemy = ranged3;
				currentDifficulty += ranged3Difficulty;
			}

			Instantiate(currentEnemy, Random.insideUnitCircle * 3, Quaternion.Euler(0f,0f,0f) );
			yield return new WaitForSeconds(0.5f);
		}

		yield return 0; // stops from crashing
	}


	// Update is called once per frame
	void Update () {

	}
}
