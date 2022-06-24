using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class _01_DrawGizmos : MonoBehaviour
{
	BoxCollider _boxCollider;
	BoxCollider boxCollider {
		get
		{
			if (_boxCollider == null)
			{
				_boxCollider = GetComponent<BoxCollider>();
			}
			return _boxCollider;
		}
	}


	// OnDrawGizmos()会在编辑器的Scene视图刷新的时候被调用
	// 我们可以在这里绘制一些用于Debug的数据
	void OnDrawGizmos()
	{

		Gizmos.color = new Color(1f, 0f, 0f, 1f);
		Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);

		Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
		Gizmos.DrawCube(transform.position + boxCollider.center, boxCollider.size);
	}

	// OnDrawGizmosSelect()类似于OnDrawGizmos()，它会在当该组件所属的物体被选中时被调用
	void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1f, 1f, 0f, 1f);
		Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);

		Gizmos.color = new Color(1f, 1f, 0f, 0.3f);
		Gizmos.DrawCube(transform.position + boxCollider.center, boxCollider.size);
	}
}

