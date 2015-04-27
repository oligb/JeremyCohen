using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour {

	public GameObject player;
	public float energy;
	public float maxEnergy;
	public Vector3 startScale;
	// Use this for initialization
	void Start () {
		startScale=transform.localScale;
		player=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

		energy=player.GetComponent<PlayerMoveQueueing>().currentEnergy;
		maxEnergy=player.GetComponent<PlayerMoveQueueing>().maxEnergy;

		float barScaler=energy/maxEnergy;
		transform.localScale= new Vector3(barScaler*startScale.x,startScale.y,startScale.z);
	
	}
}
