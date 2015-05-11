using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour {


	bool mouseOver = false;
	public GameObject actualUpgradeObject;
	public string statName;
	public float statValue;
	// Use this for initialization

	void OnMouseEnter(){
		mouseOver = true;
	
	}

	void OnMouseExit(){
		mouseOver = false;
	}

	void OnGUI() {
		if ( mouseOver){

			GUI.Box(new Rect(Input.mousePosition.x + 10 , Screen.height + 10  - Input.mousePosition.y, 200, 30), 
			        new GUIContent(statName + ": +" + statValue.ToString()));

		}

	}
}
