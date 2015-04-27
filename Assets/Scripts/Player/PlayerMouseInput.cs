using UnityEngine;
using System.Collections;

public class PlayerMouseInput : MonoBehaviour {

	public PlayerAttacks attacks;
	public Vector3 targetPos;
	void Start () {
		attacks= GetComponent<PlayerAttacks>();
	}
	
	// Update is called once per frame
	void Update () {

		
		Ray cursorRay= Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit cursorRayHit= new RaycastHit();
		
		
		if(Physics.Raycast(cursorRay, out cursorRayHit, 1000f)){
		
				targetPos=cursorRayHit.point;
				targetPos.y=0f;
		
			if (Input.GetMouseButton(0)){
				attacks.Shoot(transform.position,targetPos);
			}
		}
		
	//	transform.LookAt(targetPos);


	}
}


