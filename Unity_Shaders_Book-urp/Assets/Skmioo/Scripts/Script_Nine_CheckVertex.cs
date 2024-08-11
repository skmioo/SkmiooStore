using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Script_Nine_CheckVertex : MonoBehaviour
{

	public MeshFilter mf;
	float maxX;
	float minX;
	void Start()
	{
		mf = GetComponent<MeshFilter>();
		Vector3[] verts = mf.mesh.vertices;
		maxX = verts.Max((v) => v.x);
		minX = verts.Min((v) => v.x);

	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
