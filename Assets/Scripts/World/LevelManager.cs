using UnityEngine;
using System.Collections;


public class LevelManager : MonoBehaviour {

	public GameObject text;

	public float level = 1;
	public float pyramidHealth = 15;
	public float pyramidSpeed = 0.1f;
	public int pyramidNumOfBullets = 3;
	public float numberOfEnemies = 0.08f;
	public float pyramidBulletSpeed = 150;

	public float maxXTiles = 10;
	public float maxYTiles = 10;

	public float armoredHealth = 10;
	public float armoredSpeed = 5;

	public float basicHealth = 10;
	public float basicSpeed = 10;

	public GameObject currentMapmaker;

	// Use this for initialization
	void Start () {
		text.GetComponent<TextMesh>().text = "Level: " + level.ToString();

		//tempPyramid = currentMapmaker.GetComponent<MapMakerV7>().pyramidEnemy;
		//Debug.Log(rangedEnemyInstance.name);
	}
	
	// Update is called once per frame
	void Update () {
	}
	

	public void IncreaseDifficulty(){
		numberOfEnemies = numberOfEnemies + 0.012f;

		pyramidSpeed = pyramidSpeed + level / 30f;
		pyramidHealth = pyramidHealth + level;
		pyramidNumOfBullets = pyramidNumOfBullets + 1;
		pyramidBulletSpeed = pyramidBulletSpeed + pyramidBulletSpeed / 20f;

		armoredHealth = armoredHealth + level;
		armoredSpeed = armoredSpeed + armoredSpeed / 10;

		basicHealth = basicHealth + level;
		basicSpeed = basicSpeed + basicSpeed / 10;

		maxXTiles = maxXTiles + level * 2;
		maxYTiles = maxYTiles + level * 2;

		text.GetComponent<TextMesh>().text = "Level: " + level.ToString();

	}
}
