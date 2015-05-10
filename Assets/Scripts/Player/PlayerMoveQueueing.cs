using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMoveQueueing: MonoBehaviour {

	// Use this for initialization
	List<Vector3> queuedStepList = new List<Vector3>();
	List<Vector3> shotTargets = new List<Vector3>();
	List<GameObject> placeholderLines = new List<GameObject>();

	public GameObject lineObject;
	public GameObject trailHolder;
	public GameObject overlay;
	public GameObject ghostHolder;
	public GameObject barStuffHolder;
	public GameObject coneObject;

	public float stepSize=5f;
	public float stepDelay=1f;
	public float delayWhileShooting=2f;
	public Vector3 currentTarget;

	Vector3 shootSignalVector=new Vector3(100f,100f,100f);
	PlayerController playerControl;
	PlayerAttacks playerAttack; 
	int currentShotIterator=0;
	LookatMouse triangleLook;

	public bool queueing=false;
	public bool playingBack=false;
	public bool timeStopped=false;

	public float maxEnergy=100f;
	public float currentEnergy=100f;
	public float energyDepletionRate=.5f;
	public float shotEnergyDepletionRate=10f;
	public float energyRechargeRate=.3f;

	Vector3 posAtQueStart;
	float energyAtQueStart;

	void Start () {
		triangleLook=GetComponentInChildren<LookatMouse>();
		barStuffHolder=GameObject.Find("StuffHolder");
		overlay=GameObject.Find("Overlay");
		playerControl=GetComponent<PlayerController>();
		playerAttack=GetComponent<PlayerAttacks>();
	//	currentEnergy=maxEnergy;

	}
	
	// Update is called once per frame
	void Update () {

		if(queueing || playingBack){
			timeStopped=true;
		}
		else{
			timeStopped=false;
		}


		if(queueing){
			if(currentEnergy-energyDepletionRate<=energyDepletionRate &&currentEnergy<=1f){
				GetComponent<Rigidbody>().velocity=Vector3.zero;
				playerControl.canMove=false;
			}
			else{
				playerControl.canMove=true;
			}
			overlay.gameObject.SetActive(true);
		}
		else{

			overlay.gameObject.SetActive(false);
		}	

		if(currentEnergy<maxEnergy && !queueing && !playingBack){
			currentEnergy+=energyRechargeRate;
		}
		if(currentEnergy>maxEnergy){
			currentEnergy=maxEnergy;
		}
		else if(currentEnergy<=-3f){
			GetComponent<PlayerStateControls>().Kill();
		}


		if(Input.GetKeyDown("space") && queueing ){
			StopCoroutine("Queueing");
			queueing=false;
			StartCoroutine("PlaybackQue");
		}

		if(Input.GetKeyDown("space") && !queueing && !playingBack && currentEnergy>=0f){
			posAtQueStart=transform.position;
			energyAtQueStart=currentEnergy;
			StartCoroutine("Queueing");
		}


		if(Input.GetKeyDown(KeyCode.Escape) && queueing ){
			GameObject trailClone =GameObject.Find("trailHolder(Clone)");
			Destroy(trailClone.gameObject);
			Destroy(GameObject.Find("GhostHolder(Clone)"));

			StopCoroutine("Queueing");
			queuedStepList.Clear();
			shotTargets.Clear();
			queueing=false;

			foreach(GameObject cone in placeholderLines){
				Destroy(cone);
			}
			placeholderLines.Clear();

			transform.position=posAtQueStart;
			currentEnergy=energyAtQueStart;

		}




		if ((Input.GetMouseButtonDown(0) ||Input.GetKeyDown(KeyCode.P)) && !playingBack && queueing){



		Ray cursorRay= Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit cursorRayHit= new RaycastHit();

		if(Physics.Raycast(cursorRay, out cursorRayHit, 1000f)){
			
				if(queueing  && currentEnergy-shotEnergyDepletionRate>=0f){
				queuedStepList.Add(transform.position);
				queuedStepList.Add(shootSignalVector);
				currentEnergy-=shotEnergyDepletionRate;

				Vector3 targetPos=cursorRayHit.point;
				targetPos.y=transform.position.y;
				shotTargets.Add(targetPos);

			

				GameObject cone= Instantiate(coneObject,transform.position,Quaternion.identity) as GameObject;
					cone.transform.LookAt(targetPos);
					cone.GetComponentInChildren<GenerateArc>().shotArc=playerAttack.shotArc;
					cone.GetComponentInChildren<GenerateArc>().radius=playerAttack.maxRange;
					cone.GetComponentInChildren<GenerateArc>().GenerateCone();
					placeholderLines.Add(cone);


				}
				else{
					barStuffHolder.GetComponent<ShakeBar>().TriggerShake();
				}
				/*
				else{
					if(currentEnergy>=0f){
					Vector3 targetPos=cursorRayHit.point;
					targetPos.y=transform.position.y;
					playerAttack.Shoot(transform.position,targetPos);
					}
				}
				*/
			}


		
		}
	}


	public IEnumerator PlaybackQue(){
		if(shotTargets.Count>0){
		triangleLook.Target(shotTargets[0]);
		}

		GameObject trailClone =GameObject.Find("trailHolder(Clone)");
		trailClone.transform.parent=null; 
		Destroy(GameObject.Find("GhostHolder(Clone)"));
		GetComponent<Rigidbody>().velocity=Vector3.zero;
		playingBack=true;
		StopCoroutine("Queueing");
		playerControl.canMove=false;
		int i=0;
		int numSteps=queuedStepList.Count;
		while(i<=numSteps-1){
		
			if(queuedStepList[i]==shootSignalVector){
				triangleLook.Target(shotTargets[currentShotIterator]);

				yield return new WaitForSeconds(delayWhileShooting/2);
				playerAttack.Shoot(transform.position,shotTargets[currentShotIterator]);

				Destroy(placeholderLines[currentShotIterator].gameObject);
				yield return new WaitForSeconds(delayWhileShooting/2);
				currentShotIterator++;
				i++;


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
		playerControl.canMove=true;
		playingBack=false;
		yield break;

	}

	public IEnumerator Queueing(){	
		Mesh ghostMesh = GetComponent<MeshFilter>().mesh;
		GameObject ghostInPlace = Instantiate(ghostHolder,transform.position,Quaternion.identity) as GameObject;
		ghostInPlace.GetComponent<MeshFilter>().mesh=ghostMesh;
		ghostInPlace.transform.localScale=transform.localScale*.9f;

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
