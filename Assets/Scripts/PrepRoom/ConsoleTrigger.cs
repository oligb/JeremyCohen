using UnityEngine;
using System.Collections;

public class ConsoleTrigger : MonoBehaviour {


	void Update() {

	}

	void ShowMenu(){
	
	}

	void OnTriggerStay(){

		if(Input.GetKeyDown("space")){
			ShowMenu();
		}

	}
}
