using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//字面翻译就是在编辑器模式下调用。
//在正常运行的时候还是可以调用的。
//ExecuteInEditMode需要写在类上面
[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class TestTriangle : MonoBehaviour
{

	public float sideLength = 2;
	public float angleDegree = 100;

	private MeshFilter meshFilter;


	void Awake()
	{
		Debug.Log("111");
		meshFilter = GetComponent<MeshFilter>();
		meshFilter.mesh = create(sideLength, angleDegree);
	}

	Mesh create(float sideLength, float angleDegree)
	{
		Mesh mesh = new Mesh();
		//Mesh 顶点数据
		Vector3[] vertices = new Vector3[3];
		//转化成pi类型的值
		float angle = Mathf.Deg2Rad * angleDegree;
		float halfAngle = angle * 0.5f;
		vertices[0] = Vector3.zero;
		float cosA = Mathf.Cos(halfAngle);
		float sinA = Mathf.Sin(halfAngle);
		vertices[1] = new Vector3(cosA * sideLength, 0, sinA * sideLength);
		vertices[2] = new Vector3(cosA * sideLength, 0, -sinA * sideLength);

		//Mesh 三角形数据
		int[] triangles = new int[3];
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;

		mesh.vertices = vertices;
		mesh.triangles = triangles;


		Vector2[] uvs = new Vector2[vertices.Length];
		uvs[0] = new Vector2(0, 0.5f);
		uvs[1] = Vector2.one;
		uvs[2] = Vector2.right;

		mesh.uv = uvs;
		mesh.name = "TriAngle";

		return mesh;
	}


	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		DrawMesh();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		DrawMesh();
	}

	private void DrawMesh()
	{
		Mesh mesh = meshFilter.sharedMesh;
		if (mesh == null)
			return;
		Gizmos.DrawLine(mesh.vertices[mesh.triangles[0]], mesh.vertices[mesh.triangles[1]]);
		Gizmos.DrawLine(mesh.vertices[mesh.triangles[1]], mesh.vertices[mesh.triangles[2]]);
		Gizmos.DrawLine(mesh.vertices[mesh.triangles[2]], mesh.vertices[mesh.triangles[0]]);

	}
}
