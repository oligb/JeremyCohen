using UnityEngine;
using System.Collections;

public class EnemyPushback : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RelativePush(float pushbackForce){
		GetComponent<Rigidbody>().AddRelativeForce(0f,0f,-pushbackForce,ForceMode.Impulse);
	}
}
