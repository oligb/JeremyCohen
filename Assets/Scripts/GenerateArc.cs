using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateArc : MonoBehaviour {

	// Use this for initialization

	
	public float angleStepSize=5f;
	public float shotArc=30f;
	public float radius=5f;
	public float height=1f;

	public float newTrianglesSpeed=.5f;
	public Vector3 playerOrigin;
	
	public void GenerateCone(){
		StartCoroutine("AddTriangles");
	}

	IEnumerator AddTriangles(){


		Mesh mesh = GetComponent<MeshFilter>().mesh;
		MeshBuilder builder=new MeshBuilder();

		builder.Vertices.Add(playerOrigin);
		builder.Vertices.Add(playerOrigin+ Vector3.right*radius);

		int i=1;

			for(float angle=angleStepSize; angle<=shotArc/2f; angle+=angleStepSize){
				float angleInRadians=angle*(Mathf.PI/180);
			
				Vector3 posOnCircle = Vector3.zero;
				posOnCircle.x = Mathf.Cos(angleInRadians);
				posOnCircle.z = Mathf.Sin(angleInRadians);
				
				Vector3 oppositePosOnCircle = Vector3.zero;
				oppositePosOnCircle.x = Mathf.Cos(-angleInRadians);
				oppositePosOnCircle.z = Mathf.Sin(-angleInRadians);


				builder.Vertices.Add(playerOrigin + posOnCircle * radius);
				builder.Vertices.Add(playerOrigin + oppositePosOnCircle * radius);


			if(i==1){
				builder.AddTriangle(0,1,2);
				builder.AddTriangle(0,1,3);
			}
			else{
				builder.AddTriangle(0,i*2-2,i*2);
				builder.AddTriangle(0,i*2-1,i*2+1);
			}

			i++;
				mesh.Clear();
				GetComponent<MeshFilter>().mesh=builder.CreateMesh();
			//newTrianglesSpeed
			//yield return new WaitForSeconds(newTrianglesSpeed);
			yield return 0;
			}

		yield break;

	}
	

}
		                      