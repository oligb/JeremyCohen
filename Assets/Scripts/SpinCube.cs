using UnityEngine;
using System.Collections;

public class SpinCube : MonoBehaviour {

	// Use this for initialization
	public float rotSpeed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0f,rotSpeed,0f));
	
	}
}
