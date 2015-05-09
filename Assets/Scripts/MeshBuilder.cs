using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshBuilder
{
	private List<Vector3> m_Vertices = new List<Vector3>();
	public List<Vector3> Vertices { get { return m_Vertices; } }
	
	private List<int> m_Indices = new List<int>();
	
	public void AddTriangle(int index0, int index1, int index2)
	{
		m_Indices.Add(index0);
		m_Indices.Add(index1);
		m_Indices.Add(index2);
	}
	
	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh();
		
		mesh.vertices = m_Vertices.ToArray();
		mesh.triangles = m_Indices.ToArray();
		mesh.RecalculateBounds();
		
		return mesh;
	}
}