using UnityEngine;
using System.Collections;

public class fixPos : MonoBehaviour {

	// Use this for initialization
	Vector3 startPos;
	public float floorOffsetScale=.1f;
	void Start () {

		startPos=transform.position;

		startPos.y-=startPos.z*floorOffsetScale;
		transform.position=startPos;
	
	}

	void OnCollisionStay(Collision col){
		if(col.gameObject.name=="Floor"){

			Destroy(col.gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		
	
	}
}
