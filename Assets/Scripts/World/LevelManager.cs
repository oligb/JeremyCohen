using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float level = 1;
	public float pyramidHealth = 15;
	public float pyramidSpeed = 0.1f;
	public int pyramidNumOfBullets = 3;
	public float numberOfEnemies = 0.08f;
	public float pyramidBulletSpeed = 150;
	public GameObject currentMapmaker;
	public GameObject tempPyramid;
	public GameObject armoredEnemeyPrefab, rangedEnemyPrefab;
	public GameObject armoredEnemyInstance, rangedEnemyInstance;
	// Use this for initialization
	void Start () {

		//tempPyramid = currentMapmaker.GetComponent<MapMakerV7>().pyramidEnemy;
		//Debug.Log(rangedEnemyInstance.name);
	}
	
	// Update is called once per frame
	void Update () {
	}
	

	public void IncreaseDifficulty(){
		numberOfEnemies = numberOfEnemies + 0.01f;
		pyramidSpeed = pyramidSpeed + level / 20f;
		pyramidHealth = pyramidHealth + level;
		pyramidNumOfBullets = pyramidNumOfBullets + 1;
		pyramidBulletSpeed = pyramidBulletSpeed + pyramidBulletSpeed / 20f;


	}
}
