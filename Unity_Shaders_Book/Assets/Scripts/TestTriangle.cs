using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestTriangle : MonoBehaviour
{
	public Transform a;
	public Transform b;
	public Transform c;
	public Transform point;
	Vector3 ap { get { return a.transform.position; } }
	Vector3 bp { get { return b.transform.position; } }
	Vector3 cp { get { return c.transform.position; } }
	Vector3 pointp { get { return point.transform.position; } }
	// Start is called before the first frame update

	bool IsIn = false;
	private void Update()
	{
		drawTriangle();
		if (checkInTriangle() != IsIn)
		{
			IsIn = !IsIn;
			Debug.Log("IsIn:" + IsIn);
		}
	}

	private bool checkInTriangle()
	{
		Vector3 pa = ap - pointp;
		Vector3 pb = bp - pointp;
		Vector3 pc = cp - pointp;
		//Debug.Log(Vector3.Angle(pa, pb));
		Vector3 cpab = Vector3.Cross(pa, pb);
		Vector3 cpbc = Vector3.Cross(pb, pc);
		Vector3 cpca = Vector3.Cross(pc, pa);

		Debug.DrawLine(pointp, pointp + cpab, Color.green);
		Debug.DrawLine(pointp, pointp + cpbc, Color.blue);
		Debug.DrawLine(pointp, pointp + cpca, Color.yellow);

		Debug.DrawLine(pointp, ap, Color.black);
		Debug.DrawLine(pointp, bp, Color.black);
		Debug.DrawLine(pointp, cp, Color.black);

		float dot1 = Vector3.Dot(cpab,cpbc);
		float dot2 = Vector3.Dot(cpbc, cpca);
		float dot3 = Vector3.Dot(cpca, cpab);
		dot1 = dot1 / Mathf.Abs(dot1);
		dot2 = dot2 / Mathf.Abs(dot2);
		dot3 = dot3 / Mathf.Abs(dot3);
		Vector3 ab = bp - ap;


		float v = Vector3.Dot(cpbc, ab);
		bool isInTriangle = Mathf.Approximately(v, 0);

		return isInTriangle && dot1 == dot2 && dot2 == dot3;
	}

	bool checkInTriangle2()
	{
		Plane p = new Plane(ap, bp, cp);
		float dis = p.GetDistanceToPoint(pointp); 
		return Mathf.Approximately(dis, 0);
	}

	void drawTriangle()
	{
		Debug.DrawLine(ap,bp,Color.red);
		Debug.DrawLine(bp, cp, Color.red);
		Debug.DrawLine(cp, ap, Color.red);
	}
    
}
