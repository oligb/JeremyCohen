using UnityEngine;
using System.Collections;

public class RotateWingThings : MonoBehaviour {

	// Use this for initialization
	public float rotSpeed=5f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(rotSpeed,0f,0f);
	}
}
