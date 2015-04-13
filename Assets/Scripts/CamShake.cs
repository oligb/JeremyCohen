using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {

	// Use this for initialization
	public float duration=1f;
	public float magnitude=10f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	public void TriggerShake(){

		StartCoroutine(Shake ());

	}
	IEnumerator Shake() {
		
		float elapsed = 0.0f;
		
		Vector3 originalCamPos = transform.position;
		
		while (elapsed < duration) {
			
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
			
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			y *= magnitude * damper;
			
			transform.position = new Vector3(x, originalCamPos.y, y);
			
			yield return null;
		}
		
		transform.position = originalCamPos;
	}
}
