using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Script_Two_Matrix : MonoBehaviour
{
	void Update()
	{
		Matrix4x4 rm = new Matrix4x4();
		rm[0, 0] = Mathf.Cos(Time.realtimeSinceStartup);
		rm[0, 2] = Mathf.Sin(Time.realtimeSinceStartup);
		rm[1, 1] = 1;
		rm[2, 0] = -Mathf.Sin(Time.realtimeSinceStartup);
		rm[2, 2] = Mathf.Cos(Time.realtimeSinceStartup);
		rm[3, 3] = 1;

		Matrix4x4 sm = new Matrix4x4();
		sm[0, 0] = Mathf.Sin(Time.realtimeSinceStartup) * 0.2f + 0.5f;
		sm[1, 1] = Mathf.Cos(Time.realtimeSinceStartup) * 0.2f + 0.5f;
		sm[2, 2] = Mathf.Sin(Time.realtimeSinceStartup) * 0.2f + 0.5f;
		sm[3, 3] = 1;
		//Matrix4x4 mvp = Camera.main.projectionMatrix * Camera.main.worldToCameraMatrix * transform.localToWorldMatrix;

		GetComponent<Renderer>().material.SetMatrix("rm", rm);
		GetComponent<Renderer>().material.SetMatrix("sm", sm);
		//GetComponent<Renderer>().material.SetMatrix("mvp", mvp);
	}
}

