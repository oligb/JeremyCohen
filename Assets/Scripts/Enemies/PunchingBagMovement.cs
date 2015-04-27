using UnityEngine;
using System.Collections;

public class PunchingBagMovement : MonoBehaviour {

	// Use this for initialization
	public float perlinInc=.1f;
	public float perlinLoc=100f;
	public float perlinScale=5f;
	public Vector3 startPos;
	void Start () {
		startPos=transform.position;
		perlinLoc+=Random.Range (0,500f);
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 perlinMove=new Vector3(startPos.x+(.5f-Mathf.PerlinNoise(perlinLoc,0f))*perlinScale*3f,startPos.y,startPos.z+(.5f-Mathf.PerlinNoise(perlinLoc+50f,0f))*perlinScale);
		transform.position=perlinMove;
			perlinLoc+=perlinInc;
	}
}
