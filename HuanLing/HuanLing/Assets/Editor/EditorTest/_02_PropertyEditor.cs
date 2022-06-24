using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(_02_Property))]
public class _02_PropertyEditor : Editor
{
	_02_Property m_Target;

	private void OnEnable()
	{
		m_Target = (_02_Property)target;
	}

	public override void OnInspectorGUI()
	{
		// DrawDefaultInspector告诉Unity按照默认的方式绘制面板，这种方法在我们仅仅想要自定义某几个属性的时候会很有用
		DrawDefaultInspector();
		DrawCameraHeightPreviewSlider();  

	}

	void DrawCameraHeightPreviewSlider()
	{
		GUILayout.Space(10);

		Vector3 cameraPosition = m_Target.transform.position;
		cameraPosition.y = EditorGUILayout.Slider("Camera Height", cameraPosition.y, m_Target.MinimumHeight, m_Target.MaximumHeight);

		if (cameraPosition.y != m_Target.transform.position.y)
		{
			// 改变状态前，使用该方法来记录操作，以便之后Undo
			Undo.RecordObject(m_Target, "Change Camera Height");
			m_Target.transform.position = cameraPosition;
		}
	}

}

