using UnityEngine;
using System.Collections;

public class SetText : MonoBehaviour {

	// Use this for initialization
	TextMesh text;
	public int usedPoints;
	public int availablePoints;
	PlayerUpgradeManager player;
	void Start () {
		player=GameObject.Find("Player").GetComponent<PlayerUpgradeManager>();
		text=GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

		usedPoints=player.usedUpgradePoints;
		availablePoints=player.currentUpgradePoints;

		text.text=usedPoints+ " / " +availablePoints;
	
	}
}
