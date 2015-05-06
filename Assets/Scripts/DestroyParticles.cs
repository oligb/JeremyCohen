using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("Kill",2f);
	
	}
	void Kill(){
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
