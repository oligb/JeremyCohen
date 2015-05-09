using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateArc : MonoBehaviour {

	// Use this for initialization

	
	public float angleStepSize=5f;
	public float totalDuration=1f;
	public float shotArc=30f;
	public float radius=5f;
	public float height=1f;

	public float newTrianglesSpeed=.5f;
	public Vector3 playerOrigin;

	void Start () {
		StartCoroutine("AddTriangles");
	}

	IEnumerator AddTriangles(){


		Mesh mesh = GetComponent<MeshFilter>().mesh;
		MeshBuilder builder=new MeshBuilder();

		builder.Vertices.Add(playerOrigin);
		builder.Vertices.Add(playerOrigin+ Vector3.right*radius);

		int i=1;

			for(float angle=angleStepSize; angle<=shotArc/2f; angle+=angleStepSize){
			Debug.Log("forloop"+i);
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

				yield return new WaitForSeconds(newTrianglesSpeed);
			}


	}
	










	/*

			void MakeRing(float angleStep){
		MeshBuilder builder = new MeshBuilder();

		BuildRing(builder, 5, Vector3.zero, radius, 0.0f, false);
		BuildRing(builder, 5, Vector3.up * height, radius, 1.0f, true);

		
		GetComponent<MeshFilter>().mesh=builder.CreateMesh();

		}


	void BuildRing(MeshBuilder meshBuilder, int segmentCount, Vector3 centre, float radius, 
	               float v, bool buildTriangles)
	{
		float angleInc = (Mathf.PI * 2.0f) / segmentCount;
		
		for (int i = 0; i <= segmentCount; i++)
		{
			float angle = angleInc * i;
			
			Vector3 unitPosition = Vector3.zero;
			unitPosition.x = Mathf.Cos(angle);
			unitPosition.z = Mathf.Sin(angle);
			
			meshBuilder.Vertices.Add(centre + unitPosition * radius);
			
			if (i > 0 && buildTriangles)
			{
				int baseIndex = meshBuilder.Vertices.Count - 1;
				
				int vertsPerRow = segmentCount + 1;
				
				int index0 = baseIndex;
				int index1 = baseIndex - 1;
				int index2 = baseIndex - vertsPerRow;
				int index3 = baseIndex - vertsPerRow - 1;
				
				meshBuilder.AddTriangle(index0, index2, index1);
				meshBuilder.AddTriangle(index2, index3, index1);
			}
		}
	}




*/

}
		                      