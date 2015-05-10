using UnityEngine;
using System.Collections;

public class LookatMouse : MonoBehaviour
{
	public float speed;
	public float playbackTurnSpeed;
	float startSpeed;
	Vector3 targetPos;
	public PlayerMoveQueueing player;
	void Start(){
		startSpeed=speed;
		player=transform.parent.GetComponent<PlayerMoveQueueing>();

	}

	public void Target(Vector3 shotTarget){
		targetPos=shotTarget;
	}
	
	void FixedUpdate () {

		if(player.playingBack){
			speed=playbackTurnSpeed;
			Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}
		else{
			speed=startSpeed;
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitdist = 0.0f;
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}
		}
	}
}