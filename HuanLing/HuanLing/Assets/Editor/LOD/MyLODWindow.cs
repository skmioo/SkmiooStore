#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LODWindow : EditorWindow
{

	enum WorkType
	{
		Scene = 0,
		Role,
		Hair,
		HeadGear,   //头饰    
		Weapon,
		Horse,
	}

	string[] LodTypes = new string[] { "LOD0", "LOD0-1", "LOD0-2", "LOD0-3" };

	readonly static float[] c_LOD0 = { 0.1f };
	readonly static float[] c_LOD1 = { 0.5f, 0f };
	readonly static float[] c_LOD2 = { 0.6f, 0.3f, 0f };
	readonly static float[] c_LOD3 = { 0.6f, 0.3f, 0.15f, 0f };
	readonly static float[] c_LOD4 = { 0.75f, 0.5f, 0.25f, 0.13f, 0f };
	readonly static float[] c_LOD5 = { 0.8f, 0.6f, 0.4f, 0.2f, 0.1f, 0f };
	readonly static float[][] c_LODSRTs = new float[6][] { c_LOD0, c_LOD1, c_LOD2, c_LOD3, c_LOD4, c_LOD5 };

	private static float[] getSRTs(int nLODCount)
	{
		float[] srtsRet = null;
		if (nLODCount >= 0 && nLODCount <= 5)
		{
			srtsRet = c_LODSRTs[nLODCount];
		}
		return srtsRet;
	}

	List<float> m_SimplifyParams = new List<float>();
	List<float> m_LODSRTs = new List<float>();
	WorkType m_WorkType;
	int m_nSelectedLODType = 0;

	const float c_fMaxRatio = 0.95f;
	const float c_fMinRatio = 0.01f;
	static float clampRemoveFaceRatio(float fRatio)
	{
		return Mathf.Clamp(fRatio, c_fMinRatio, c_fMaxRatio);
	}

	private void OnGUI()
	{
		m_WorkType = (WorkType)EditorGUILayout.EnumPopup(m_WorkType);


		switch (m_WorkType)
		{
			case WorkType.Scene:
				m_nSelectedLODType = EditorGUILayout.Popup(m_nSelectedLODType, LodTypes);
				int nLODCount = m_nSelectedLODType;

				MyLODGroupCreator.s_SearchAllRenderer = (nLODCount == 0);

				if (m_SimplifyParams.Count < nLODCount)
				{
					for (int nLOD = m_SimplifyParams.Count; nLOD <= nLODCount; nLOD++)
					{
						float fDefault = 0.2f;
						if (m_SimplifyParams != null && m_SimplifyParams.Count > 0)
						{
							fDefault = m_SimplifyParams[m_SimplifyParams.Count - 1] + 0.1f;
							fDefault = clampRemoveFaceRatio(fDefault);
						}
						m_SimplifyParams.Add(fDefault);
					}
				}
				int nLODSizeCount = m_nSelectedLODType + 1;

				if (m_LODSRTs.Count != nLODSizeCount)
				{
					var srts = getSRTs(nLODCount);
					m_LODSRTs = new List<float>(srts);
				}

				break;
		}



		GUILayout.Label(string.Format("{0}相对屏幕比例", LodTypes[m_nSelectedLODType]));
	
	}

	[MenuItem("Skmioo/Lod")]
	static void OpenWindow()
	{
		LODWindow window = GetWindow<LODWindow>();
		window.Show();
	}
}
#endif