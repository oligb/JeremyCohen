using UnityEngine;
using System.Collections;

public class pathinstance : MonoBehaviour {


	public int max_tiles = 50;
	int counter = 0;
	float random_number;

	public GameObject floortile;

	public GameObject gridmaker;
	public float gridmaker_chance = 0.01f;
	public int cooldown_timer = 10;
	int cooldown = 10;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}
	
		if (counter < max_tiles){
			random_number = Random.value;

			Instantiate(floortile, gameObject.transform.position, gameObject.transform.rotation);
			if (random_number < 0.25f){
				transform.Rotate(0,90,0);
			} else if ( random_number < 0.5f){
				transform.Rotate(0,-90,0);
			} 
			transform.Translate(Vector3.forward * 5 );

			if (cooldown == 0){
				if (random_number < gridmaker_chance ){
					Instantiate(gridmaker, gameObject.transform.position , gameObject.transform.rotation);
					cooldown = cooldown_timer;
				}
			} else {
				cooldown--;
			}

			counter++;
		} else{
			Destroy(gameObject);
		}
			
	}

	void OnTriggerEnter(Collider collided_object){
		Debug.Log("DESTROYED WITH EXTREME PREJUDICE");
		Destroy(collided_object.gameObject);

	}
}
