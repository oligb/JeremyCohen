using UnityEngine;
using System.Collections;

public class gridinstance : MonoBehaviour {
	
	
	public int max_tiles = 50;
	public GameObject floortile;
	public GameObject walltile;

	public GameObject pathmaker;
	public float pathmaker_chance = 0.01f;

	int counter = 0;
	float random_number;
	


	
	// Use this for initialization
	void Start () {
		for (int x = 0; x < 5; x++){
			for ( int z = 0; z < 5; z++){
				Vector3 position = new Vector3(x * 5, 0, z * 5) + gameObject.transform.position;
				random_number = Random.value;
				if (random_number < 0.7f){
					Instantiate(floortile, position, gameObject.transform.rotation);
				} else if (random_number < 0.95f){
					Instantiate(walltile, position, gameObject.transform.rotation);
				}
				if (random_number < pathmaker_chance ){
					Instantiate(pathmaker, position, gameObject.transform.rotation);
				}
			}
		}
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		

		
	}
}
