	using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	// Use this for initialization
	public GameObject barRefillParticle;
	public int energyRestored=5;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void KillEnemy(){
		for(int i=1;i<energyRestored+1; i++){
		GameObject cube= Instantiate (barRefillParticle,transform.position,Quaternion.identity) as GameObject;
			cube.transform.Rotate(0f,i*360/energyRestored,0f);
			cube.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*300f);

		}
		Destroy(gameObject);
	}
}
