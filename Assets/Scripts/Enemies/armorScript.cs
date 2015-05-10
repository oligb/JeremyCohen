using UnityEngine;
using System.Collections;

public class armorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider item){

		if(item.gameObject.name.StartsWith("bullet1")){
			Debug.Log("ArmorHit on armor.");

			Destroy(item);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
