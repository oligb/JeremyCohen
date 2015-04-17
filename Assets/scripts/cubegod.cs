using UnityEngine;
using System.Collections;

public class cubegod : MonoBehaviour {

	public int maxnumber = 100;
	public float cubespawnradius = 10f;
	public Transform blueprint;
	public bool on = false;




	// Use this for initialization
	void Start () {

		maxnumber = Random.Range(100,1000);
		cubespawnradius = Random.Range(10,100);


			int cube = 0;
			if (on){
				while ( cube < maxnumber){
					Instantiate ( blueprint, Random.insideUnitCircle * cubespawnradius, Random.rotation );
					cube++;
				}
			}else{
				while ( cube < maxnumber){
					Debug.Log("I am here");
					Instantiate ( blueprint, Random.insideUnitSphere * cubespawnradius, Random.rotation );
					cube++;
				}
			}
		}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			 Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKeyDown(KeyCode.T)){
			on = !on;
		}
	}
}
