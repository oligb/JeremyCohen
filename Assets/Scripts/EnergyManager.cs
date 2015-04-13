using UnityEngine;
using System.Collections;

public class EnergyManager : MonoBehaviour {

	public GameObject player;
	public float energy;
	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

		energy=player.GetComponent<PlayerMoveQueueing>().currentEnergy;
		transform.localScale= new Vector3(energy/10f,1f,1f);
	
	}
}
