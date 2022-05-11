using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class NodeManager : MonoBehaviour
{
	public GameObject cube;
	public List<GameObject> nodes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (nodes.Count < 1)
			return;
		for (int i = 0; i < nodes.Count - 1; i++)
		{
			Debug.DrawLine(nodes[i].transform.position, nodes[i + 1].transform.position, Color.red, Time.deltaTime);
		}
    }
}
