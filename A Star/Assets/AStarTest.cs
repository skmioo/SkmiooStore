using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarTest : MonoBehaviour
{
	Seeker mySeeker;
	List<Vector3> animPoint;
	private void Awake()
	{
		mySeeker = GetComponent<Seeker>();
		mySeeker.pathCallback = pathCallback;
	}

	private void pathCallback(Path p)
	{
		animPoint = new List<Vector3>(p.vectorPath);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hitInfo))
			{
				mySeeker.StartPath(transform.position, hitInfo.point);
			}
		}
    }
	float speed = 3;
	float rotateSpeed = 3;
	private void FixedUpdate()
	{
		if (animPoint != null && animPoint.Count != 0)
		{
			Vector3 dir = (animPoint[0] - transform.position).normalized;
			//transform.LookAt(transform.position + dir);
		  Quaternion q =Quaternion.LookRotation(dir);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
			transform.position += dir * speed * Time.deltaTime;
			if (Vector3.Distance(animPoint[0], transform.position) <= 0.1f)
			{
				animPoint.RemoveAt(0);
			}
		}
	}
}
