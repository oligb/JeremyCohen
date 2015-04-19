using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMoveQueueing: MonoBehaviour {

	// Use this for initialization
	public List<Vector3> queuedStepList = new List<Vector3>();
	public List<Vector3> shotTargets = new List<Vector3>();
	public List<GameObject> placeholderLines = new List<GameObject>();

	public GameObject lineObject;
	public GameObject trailHolder;
	public GameObject overlay;
	public GameObject ghostHolder;
	public float stepSize=5f;
	public float stepDelay=1f;
	public float delayWhileShooting=2f;
	public Vector3 shootSignalVector=new Vector3(100f,100f,100f);
	public PlayerController playerControl;
	public PlayerAttacks playerAttack; 
	public int currentShotIterator=0;
	public bool queueing=false;
	public bool playingBack=false;

	public float maxEnergy=100f;
	public float currentEnergy=100f;
	public float energyDepletionRate=.5f;
	public float shotEnergyDepletionRate=10f;
	public float energyRechargeRate=.3f;

	public Vector3 posAtQueStart;
	public float energyAtQueStart;

	void Start () {
		currentEnergy=maxEnergy;
		overlay=GameObject.Find("Overlay");
		playerControl=GetComponent<PlayerController>();
		playerAttack=GetComponent<PlayerAttacks>();

	}
	
	// Update is called once per frame
	void Update () {
		if(queueing){
			overlay.gameObject.SetActive(true);
		}
		else{

			overlay.gameObject.SetActive(false);
		}	

		if(currentEnergy<maxEnergy && !queueing && !playingBack){
			currentEnergy+=energyRechargeRate;
		}

		if(Input.GetKeyDown("space") && !queueing && !playingBack){
			posAtQueStart=transform.position;
			energyAtQueStart=currentEnergy;
			StartCoroutine("Queueing");
		}

		if(Input.GetKeyDown(KeyCode.H) && queueing ){
			StopCoroutine("Queueing");
			queueing=false;
			StartCoroutine("PlaybackQue");
		}

		if(Input.GetKeyDown(KeyCode.Escape) && queueing ){

			StopCoroutine("Queueing");
			queuedStepList.Clear();
			shotTargets.Clear();
			queueing=false;

			foreach(GameObject line in placeholderLines){
				Destroy(line);
			}
			placeholderLines.Clear();

			transform.position=posAtQueStart;
			currentEnergy=energyAtQueStart;

		}




		if ((Input.GetMouseButtonDown(0) ||Input.GetKeyDown(KeyCode.P)) && !playingBack){



		Ray cursorRay= Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit cursorRayHit= new RaycastHit();

		if(Physics.Raycast(cursorRay, out cursorRayHit, 1000f)){
			
				if(queueing){
				queuedStepList.Add(transform.position);
				queuedStepList.Add(shootSignalVector);
				currentEnergy-=shotEnergyDepletionRate;

				Vector3 targetPos=cursorRayHit.point;
				targetPos.y=transform.position.y;
				shotTargets.Add(targetPos);

				GameObject line= Instantiate(lineObject,transform.position,Quaternion.identity) as GameObject;
				Vector3 shotRangeForLineRenderer=(targetPos-transform.position).normalized*playerAttack.maxRange +transform.position;
				line.GetComponent<LineRenderer>().SetPosition(0,transform.position);
				line.GetComponent<LineRenderer>().SetPosition(1,shotRangeForLineRenderer);
				placeholderLines.Add(line);
				}
				else{
					Vector3 targetPos=cursorRayHit.point;
					targetPos.y=transform.position.y;
					playerAttack.Shoot(transform.position,targetPos);
				}
			}


		
		}
	}


	public IEnumerator PlaybackQue(){
		GameObject trailClone =GameObject.Find("trailHolder(Clone)");
		trailClone.transform.parent=null; 
		Destroy(GameObject.Find("GhostHolder(Clone)"));

		playingBack=true;
		StopCoroutine("Queueing");
		GetComponent<PlayerController>().canMove=false;
		int i=0;
		int numSteps=queuedStepList.Count;

		while(i<=numSteps-1){
		
			if(queuedStepList[i]==shootSignalVector){
				playerAttack.Shoot(transform.position,shotTargets[currentShotIterator]);
				Destroy(placeholderLines[currentShotIterator].gameObject);
				currentShotIterator++;
				i++;
				yield return new WaitForSeconds(delayWhileShooting);
			}
			else{
				transform.position=queuedStepList[i];
				i++;
				yield return new WaitForSeconds(stepDelay);
			}
		}

		Destroy(trailClone);
		queuedStepList.Clear();
		shotTargets.Clear();
		placeholderLines.Clear();
		currentShotIterator=0;
		GetComponent<PlayerController>().canMove=true;
		playingBack=false;
		yield break;

	}

	public IEnumerator Queueing(){
		Mesh ghostMesh = GetComponent<MeshFilter>().mesh;
		GameObject ghostInPlace = Instantiate(ghostHolder,transform.position,Quaternion.identity) as GameObject;
		ghostInPlace.GetComponent<MeshFilter>().mesh=ghostMesh;
		ghostInPlace.transform.localScale=transform.localScale;

		GameObject trail= Instantiate(trailHolder,transform.position,Quaternion.identity) as GameObject;
		trail.transform.parent=gameObject.transform;
		queueing=true;
		Vector3 lastQuePos=transform.position;
		queuedStepList.Add(lastQuePos);
		while(true){
			if(Vector3.Distance(transform.position,lastQuePos)>stepSize){
				currentEnergy-=energyDepletionRate;
				queuedStepList.Add(transform.position);
				lastQuePos=transform.position;

			}
			yield return 0;

		}

	}
}
