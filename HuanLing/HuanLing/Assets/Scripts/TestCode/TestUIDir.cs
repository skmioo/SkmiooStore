using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIDir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		FindSelectable(transform.rotation * Vector3.left);
		print(Vector2.Scale(new Vector2(1, 2), new Vector2(2, 3)));
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void FindSelectable(Vector3 dir)
	{
		Vector3 localDir = Quaternion.Inverse(transform.rotation) * dir;
		Debug.Log("localDir :" + localDir + "   Vector3.left" + Vector3.left);
	}
}
